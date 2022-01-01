using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.Text;

#region ����
/*
 * 1. ����
 * ������ ������ �ҽ����� �����͸� �˻��ϴ� ���̴�.
 * DB������ SQL�� ���ǰ�, XML���� Xquery�� ���Ǿ���.
 * LINQ�� �پ��� ������ �ҽ� �� ���Ŀ� �ϰ��ǰ� ������ ����ϱ� ���� ���ߵǾ���.
 * 
 * 2. LINQ �۾� �з�
 *      1) ������ �ҽ� ��������
 *      2) ���� �����
 *      3) ���� ����
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

    // Enum�� byte �����ȿ��� ���
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
            new ItemDetail(){ ItemCode = 1000, OnItemUsed = () => { Debug.Log($"1000�� �������� ���Ǿ����ϴ�."); } },
            new ItemDetail(){ ItemCode = 1001, OnItemUsed = () => { Debug.Log($"1001�� �������� ���Ǿ����ϴ�."); } },
            new ItemDetail(){ ItemCode = 1002, OnItemUsed = () => { Debug.Log($"1002�� �������� ���Ǿ����ϴ�."); } },
            new ItemDetail(){ ItemCode = 1003, OnItemUsed = () => { Debug.Log($"1003�� �������� ���Ǿ����ϴ�."); } },
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
        /// ¦���� �������� �Լ�
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

            Debug.Log($"�迭������ ¦��: {msg}");
        }

        /// <summary>
        /// �迭���� ¦���� ������ �������� �Լ�
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
        /// ���ڰ� ���� ������� �����ϴ� �Լ�
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
        /// �κ��丮���� ������ ��� A �̻��� �͵��� �����մϴ�.
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
        /// Ư�� ����� �������� �κ��丮���� ã��, �ش� �������ڵ带 ����ϴ� �Լ�
        /// </summary>
        /// <param name="rarity"></param>
        void PrintSpecificedRarityItemCodes(Inventory inven, ItemRarity rarity)
        {
            // �Ű������� �޾ƿ� rarity �̻��� Item��, �κ��丮���� �������� ����
            // into Ű����� group, join, select�� ������� �ӽ������� �����ϴ� ������� ��������.
            var query =
                from item in inven.items
                group item by item.Rarity into rarityGroup
                where rarityGroup.Key >= rarity
                select rarityGroup;

            // grouping �Ǿ��ִ� ������ ����Ʈȭ�Ѵ�. ex. A - {1, 2}, B - {3}
            var group = query.ToList();

            // �츮�� ���ϴ� ���� �������̹Ƿ�, group���� Item�ΰ͵鸸 �����´�.
            // ps. SelectMany(group => group) -> Func<IGrouping<ItemRarity,Item>, IEnumerable<Item>>
            var list = group.SelectMany(group => group);

            StringBuilder sb = new StringBuilder();
            sb.Append($"{rarity}��� �̻��� ������: [");
            foreach (var item in list)
            {
                sb.Append($"{item.ItemCode}, ");
            }
            // ex. "1005, " -> "1005"               
            sb.Remove(sb.Length - 2, 2);
            sb.Append("]�� �ֽ��ϴ�.");

            Debug.Log(sb.ToString());
        }

        /// <summary>
        /// �κ��丮�� ��� �������� �ϳ��� ����մϴ�.
        /// </summary>
        /// <param name="inven"></param>
        void UseAllItem(Inventory inven, ref ItemDetail[] details)
        {
            // inventory�� itemDetails���� ���� Ű(ItemCode)�� �̿��Ͽ� ������ ����, ���ο� ���̺��� ����� ����
            var joinQuery =
                from items in inven.items
                join detail in details on items.ItemCode equals detail.ItemCode
                select new { ItemCode = items.ItemCode, ItemCount = items.ItemCount, Callback = detail.OnItemUsed };

            // ������ �ϳ��� ���
            foreach (var item in joinQuery)
            {
                item.Callback?.Invoke();
            }

            // ���� �κ��丮�� ������ ���� ���̱�
            int slotCount = inven.items.Count;
            for (int i = 0; i < slotCount; i++)
            {
                // struct �̹Ƿ� ���縦 �� ����, ������ ī��Ʈ ���̱�
                Item changed = inven.items[i];
                changed.ItemCount--;
                // �ٽ� ����
                inven.items[i] = changed;
            }
        }
    }
}

