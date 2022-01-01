using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.Text;

#region 설명
/*
 * 1. 개요
 * 쿼리는 데이터 소스에서 데이터를 검색하는 식이다.
 * DB에서는 SQL이 사용되고, XML에는 Xquery가 사용되었다.
 * LINQ는 다양한 데이터 소스 및 형식에 일관되게 쿼리를 사용하기 위해 개발되었다.
 * 
 * 2. LINQ 작업 분류
 *      1) 데이터 소스 가져오기
 *      2) 쿼리 만들기
 *      3) 쿼리 실행
 */
#endregion

namespace LINQTutorial
{
    public struct Item
    {
        public int ItemCode; // 4byte
        public ItemRarity Rarity; // 4byte
        public int ItemCount; // 1byte
    }

    // Enum을 byte 범위안에서 사용
    public enum ItemRarity : byte
    {
        C,
        B,
        A,
        S
    }

    public class Inventory
    {
        public List<Item> items;
    }

    public struct ItemDetail
    {
        public int ItemCode;
        public Action OnItemUsed;
    }

    public class LINQTest : MonoBehaviour
    {
        int[] m_numbers = new int[] { 1, 5, 3, 2, 8, 7 };
        Inventory m_inventory = new Inventory()
        {
            items = new List<Item>()
            {
                new Item(){ Rarity = ItemRarity.A, ItemCode = 1000, ItemCount = 3},
                new Item(){ Rarity = ItemRarity.S, ItemCode = 1001, ItemCount = 1},
                new Item(){ Rarity = ItemRarity.B, ItemCode = 1002, ItemCount = 2},
                new Item(){ Rarity = ItemRarity.A, ItemCode = 1003, ItemCount = 5},
                new Item(){ Rarity = ItemRarity.B, ItemCode = 1004, ItemCount = 1},
                new Item(){ Rarity = ItemRarity.C, ItemCode = 1005, ItemCount = 1},
            }
        };

        const int m_ITEM_COUNT = 5;
        ItemDetail[] m_itemDetails = new ItemDetail[m_ITEM_COUNT]
        {
            new ItemDetail(){ ItemCode = 1000, OnItemUsed = () => { Debug.Log($"1000번 아이템이 사용되었습니다."); } },
            new ItemDetail(){ ItemCode = 1001, OnItemUsed = () => { Debug.Log($"1001번 아이템이 사용되었습니다."); } },
            new ItemDetail(){ ItemCode = 1002, OnItemUsed = () => { Debug.Log($"1002번 아이템이 사용되었습니다."); } },
            new ItemDetail(){ ItemCode = 1003, OnItemUsed = () => { Debug.Log($"1003번 아이템이 사용되었습니다."); } },
            new ItemDetail(){ ItemCode = 1004  }
        };

        PerformanceIndicator m_indicator = new PerformanceIndicator();

        void PrintData(ref int[] args)
        {
            string msg = string.Empty;
            foreach (var num in args)
            {
                msg += num;
                msg += ",";
            }
            Debug.Log(msg);
        }

        /// <summary>
        /// 짝수를 가져오는 함수
        /// </summary>
        void PrintEvenData(ref int[] args)
        {
            // The Three Parts of a LINQ Query:
            // 1. Data source.
            int[] array = args;

            // 2. Query creation.
            // query is an IEnumerable<int>
            var query =
                from num in array
                where (num % 2) == 0
                select num;

            // 3. Query execution.
            string msg = string.Empty;
            foreach (int num in query)
            {
                msg += string.Format("{0}", num);
                msg += ",";
            }

            Debug.Log($"배열에서의 짝수: {msg}");
        }

        /// <summary>
        /// 배열에서 짝수의 갯수를 가져오는 함수
        /// </summary>
        int GetEvenCount(ref int[] args)
        {
            var query =
                from num in args
                where (num % 2) == 0
                select num;

            int result = query.Count();

            return result;
        }

        /// <summary>
        /// 숫자가 낮은 순서대로 정렬하는 함수
        /// </summary>
        /// <param name="args"></param>
        void SortByLow(ref int[] args)
        {
            var query =
                from num in args
                orderby num ascending
                select num;

            args = query.ToArray();
        }

        /// <summary>
        /// 인벤토리에서 아이템 등급 A 이상인 것들을 추출합니다.
        /// </summary>
        /// <param name="inven"></param>
        /// <returns></returns>
        List<Item> GetHighRarityItems(Inventory inven)
        {
            List<Item> result = new List<Item>();

            var groupQuery =
                from item in inven.items
                orderby item.Rarity
                group item by item.Rarity >= ItemRarity.A;

            foreach (var group in groupQuery)
            {
                bool isRarityHigherThanA = group.Key;
                if (isRarityHigherThanA)
                {
                    result = group.ToList();
                }
            }

            return result;
        }

        /// <summary>
        /// 특정 등급의 아이템을 인벤토리에서 찾아, 해당 아이템코드를 출력하는 함수
        /// </summary>
        /// <param name="rarity"></param>
        void PrintSpecificedRarityItemCodes(Inventory inven, ItemRarity rarity)
        {
            // 매개변수로 받아온 rarity 이상인 Item을, 인벤토리에서 가져오는 쿼리
            // into 키워드는 group, join, select의 결과물을 임시적으로 저장하는 변수라고 생각하자.
            var query =
                from item in inven.items
                group item by item.Rarity into rarityGroup
                where rarityGroup.Key >= rarity
                select rarityGroup;

            // grouping 되어있는 쿼리를 리스트화한다. ex. A - {1, 2}, B - {3}
            var group = query.ToList();

            // 우리가 원하는 것은 아이템이므로, group에서 Item인것들만 가져온다.
            // ps. SelectMany(group => group) -> Func<IGrouping<ItemRarity,Item>, IEnumerable<Item>>
            var list = group.SelectMany(group => group);

            StringBuilder sb = new StringBuilder();
            sb.Append($"{rarity}등급 이상인 아이템: [");
            foreach (var item in list)
            {
                sb.Append($"{item.ItemCode}, ");
            }
            // ex. "1005, " -> "1005"               
            sb.Remove(sb.Length - 2, 2);
            sb.Append("]가 있습니다.");

            Debug.Log(sb.ToString());
        }

        /// <summary>
        /// 인벤토리의 모든 아이템을 하나씩 사용합니다.
        /// </summary>
        /// <param name="inven"></param>
        void UseAllItem(Inventory inven, ref ItemDetail[] details)
        {
            // inventory와 itemDetails에서 공통 키(ItemCode)를 이용하여 조인한 다음, 새로운 테이블을 만드는 쿼리
            var joinQuery =
                from items in inven.items
                join detail in details on items.ItemCode equals detail.ItemCode
                select new { ItemCode = items.ItemCode, ItemCount = items.ItemCount, Callback = detail.OnItemUsed };

            // 아이템 하나씩 사용
            foreach (var item in joinQuery)
            {
                item.Callback?.Invoke();
            }

            // 실제 인벤토리의 아이템 갯수 줄이기
            int slotCount = inven.items.Count;
            for (int i = 0; i < slotCount; i++)
            {
                // struct 이므로 복사를 한 다음, 아이템 카운트 줄이기
                Item changed = inven.items[i];
                changed.ItemCount--;
                // 다시 적용
                inven.items[i] = changed;
            }
        }
    }
}

