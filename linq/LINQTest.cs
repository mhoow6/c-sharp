using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

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
            Debug.Log($"¦���� ����: {GetEvenCount(ref numbers)}");
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

