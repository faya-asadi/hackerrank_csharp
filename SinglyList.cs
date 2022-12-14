using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution {

    class SinglyLinkedListNode {
        public int data;
        public SinglyLinkedListNode next;

        public SinglyLinkedListNode(int nodeData) {
            this.data = nodeData;
            this.next = null;
        }
    }

    class SinglyLinkedList {
        public SinglyLinkedListNode head;
        public SinglyLinkedListNode tail;

        public SinglyLinkedList() {
            this.head = null;
            this.tail = null;
        }

        public void InsertNode(int nodeData) {
            SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

            if (this.head == null) {
                this.head = node;
            } else {
                this.tail.next = node;
            }

            this.tail = node;
        }
    }

    static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep, TextWriter textWriter) {
        while (node != null) {
            textWriter.Write(node.data);

            node = node.next;

            if (node != null) {
                textWriter.Write(sep);
            }
        }
    }






class Result
{

    /*
     * Complete the 'insertNodeAtPosition' function below.
     *
     * The function is expected to return an INTEGER_SINGLY_LINKED_LIST.
     * The function accepts following parameters:
     *  1. INTEGER_SINGLY_LINKED_LIST llist
     *  2. INTEGER data
     *  3. INTEGER position
     */

    /*
     * For your reference:
     *
     * SinglyLinkedListNode
     * {
     *     int data;
     *     SinglyLinkedListNode next;
     * }
     *
     */

    public static SinglyLinkedListNode insertNodeAtPosition(SinglyLinkedListNode llist, int data, int position)
    {
        var head = llist;
        var pos = 0;
        var next = head;
        while(pos < position){
            if(next == null){
                next = new SinglyLinkedListNode(0);
            }
            next = next.next;
            pos++;
        }
        var node = new SinglyLinkedListNode(data);         
        node.next = next.next;            
        next.next = node;
        return head;

    }



    static void Main(string[] args) {


        string str = "fatemeh";
        str.OrderBy(c=>c);
        Console.WriteLine(str);
        // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        // SinglyLinkedList llist = new SinglyLinkedList();

        // int llistCount = Convert.ToInt32(Console.ReadLine());

        // for (int i = 0; i < llistCount; i++) {
        //     int llistItem = Convert.ToInt32(Console.ReadLine());
        //     llist.InsertNode(llistItem);
        // }

        // int data = Convert.ToInt32(Console.ReadLine());

        // int position = Convert.ToInt32(Console.ReadLine());

        // SinglyLinkedListNode llist_head = insertNodeAtPosition(llist.head, data, position);

        // PrintSinglyLinkedList(llist_head, " ", textWriter);
        // textWriter.WriteLine();

        // textWriter.Flush();
        // textWriter.Close();
    }
}
