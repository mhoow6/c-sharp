using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

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
        public int ItemCode { get; set; }
        public ItemRarity Rarity { get; set; }
        public int ItemCount { get; set; }
    }

    public enum ItemRarity
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

    public class LINQTest : MonoBehaviour
    {
        int[] numbers = new int[] { 1, 5, 3, 2, 8, 7 };
        Inventory inventory = new Inventory()
        {
            items = new List<Item>()
            {
                new Item(){ Rarity = ItemRarity.A, ItemCode = 1000, ItemCount = 3},
                new Item(){ Rarity = ItemRarity.S, ItemCode = 1001, ItemCount = 1},
                new Item(){ Rarity = ItemRarity.B, ItemCode = 1002, ItemCount = 2},
            }
        };

        void Awake()
        {
            PrintEvenData(ref numbers);
            Debug.Log($"짝수의 갯수: {GetEvenCount(ref numbers)}");
            SortByLow(ref numbers);
            PrintData(ref numbers);
            GetHighRarityItems(inventory);
        }

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
        /// <param name="inventory"></param>
        /// <returns></returns>
        List<Item> GetHighRarityItems(Inventory inventory)
        {
            List<Item> result = new List<Item>();

            var groupQuery =
                from item in inventory.items
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
    }
}

