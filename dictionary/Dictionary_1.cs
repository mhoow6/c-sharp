using System;
using System.Collections.Generic;
using System.Text;

/*********************************
 * Dictionary(Tkey, TValue)
 * 키 집합에서 값 집합으로의 매핑을 제공
 * 클래스가 해시테이블로 구현되기 때문에
 * 키를 사용하여 값을 검색
 *********************************/

namespace Self_Study
{
    class Dictionary_1
    {
        static void Main(string[] args)
        {
            // Create a new dictionary of strings, with string keys.
            Dictionary<string, string> openWith =
                new Dictionary<string, string>();

            // Add some elements to the dictionary. There are no
            // duplicate keys, but some of the values are duplicates.
            openWith.Add("txt", "notepad.exe");
            openWith.Add("bmp", "paint.exe");
            openWith.Add("dib", "paint.exe");
            openWith.Add("rtf", "wordpad.exe");

            // The Add method throws an exception if the new key is
            // already in the dictionary.
            try
            {
                openWith.Add("txt", "winword.exe");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("An element with Key = \"txt\" already exists.");
            }

            // The Item property is another name for the indexer, so you
            // can omit its name when accessing elements.
            Console.WriteLine("For key = \"rtf\", value = {0}.",
                openWith["rtf"]);

            // The indexer can be used to change the value associated
            // with a key.
            openWith["rtf"] = "winword.exe";
            Console.WriteLine("For key = \"rtf\", value = {0}.",
                openWith["rtf"]);

            // If a key does not exist, setting the indexer for that key
            // adds a new key/value pair.
            openWith["doc"] = "winword.exe";

            // The indexer throws an exception if the requested key is
            // not in the dictionary.
            try
            {
                Console.WriteLine("For key = \"tif\", value = {0}.",
                    openWith["tif"]);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Key = \"tif\" is not found.");
            }

            // When a program often has to try keys that turn out not to
            // be in the dictionary, TryGetValue can be a more efficient
            // way to retrieve values.
            string value = "";
            if (openWith.TryGetValue("tif", out value))
            {
                Console.WriteLine("For key = \"tif\", value = {0}.", value);
            }
            else
            {
                Console.WriteLine("Key = \"tif\" is not found.");
            }

            // ContainsKey can be used to test keys before inserting
            // them.
            if (!openWith.ContainsKey("ht"))
            {
                openWith.Add("ht", "hypertrm.exe");
                Console.WriteLine("Value added for key = \"ht\": {0}",
                    openWith["ht"]);
            }

            // foreach 구문을 dictionary 요소들에게 사용할 때,
            // 요소들은 KeyValuePair 객체로써 회수된다.
            Console.WriteLine();
            foreach (KeyValuePair<string, string> kvp in openWith)
            {
                Console.WriteLine("Key = {0}, Value = {1}",
                    kvp.Key, kvp.Value);
            }

            // 값만 가져올려면 Values 속성을 사용
            Dictionary<string, string>.ValueCollection valueColl =
                openWith.Values;

            // ValueCollection의 요소들은 Dictionary 값에 대한
            // 지정된 형식으로 입력된다.
            Console.WriteLine();
            foreach (string s in valueColl)
            {
                Console.WriteLine("Value = {0}", s);
            }

            // 키 값만 가져올려면 Values 속성을 사용
            Dictionary<string, string>.KeyCollection keyColl =
                openWith.Keys;

            // KeyCollection의 요소들은 Dictionary 값에 대한
            // 지정된 형식으로 입력된다.
            Console.WriteLine();
            foreach (string s in keyColl)
            {
                Console.WriteLine("Key = {0}", s);
            }

            // Use the Remove method to remove a key/value pair.
            Console.WriteLine("\nRemove(\"doc\")");
            openWith.Remove("doc");

            if (!openWith.ContainsKey("doc"))
            {
                Console.WriteLine("Key \"doc\" is not found.");
            }

            /* This code example produces the following output:

            An element with Key = "txt" already exists.
            For key = "rtf", value = wordpad.exe.
            For key = "rtf", value = winword.exe.
            Key = "tif" is not found.
            Key = "tif" is not found.
            Value added for key = "ht": hypertrm.exe

            Key = txt, Value = notepad.exe
            Key = bmp, Value = paint.exe
            Key = dib, Value = paint.exe
            Key = rtf, Value = winword.exe
            Key = doc, Value = winword.exe
            Key = ht, Value = hypertrm.exe

            Value = notepad.exe
            Value = paint.exe
            Value = paint.exe
            Value = winword.exe
            Value = winword.exe
            Value = hypertrm.exe

            Key = txt
            Key = bmp
            Key = dib
            Key = rtf
            Key = doc
            Key = ht

            Remove("doc")
            Key "doc" is not found.
            */
        }
    }
}
