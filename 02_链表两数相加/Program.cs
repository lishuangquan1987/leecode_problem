using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02_链表两数相加
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    //Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            bool isFirstNumMorethan10 = false;
            bool isSecondNumMorethan10 = false;
            ListNode firstNode, secondNode, thirdNode;
            //firstNode = new ListNode(0);
            //secondNode = new ListNode(1);
            //thirdNode = new ListNode(2);

            if (l1.val + l2.val > 10)
            {
                isFirstNumMorethan10 = true;
                firstNode = new ListNode(l1.val + l2.val - 10);
            }
            else
            {
                firstNode = new ListNode(l1.val + l2.val);
            }

            if (l1.next.val + l2.next.val + (isFirstNumMorethan10 ? 1 : 0) > 10)
            {
                isSecondNumMorethan10 = true;
                secondNode = new ListNode(l1.next.val + l2.next.val + (isFirstNumMorethan10 ? 1 : 0) - 10);
            }
            else
            {
                secondNode = new ListNode(l1.next.val + l2.next.val + (isFirstNumMorethan10 ? 1 : 0));
            }

            if (l1.next.next.val + l2.next.next.val + (isSecondNumMorethan10 ? 1 : 0) > 10)
            {
                thirdNode = new ListNode(l1.next.next.val + l2.next.next.val + (isSecondNumMorethan10 ? 1 : 0) - 10);
            }
            else
            {
                thirdNode = new ListNode(l1.next.next.val + l2.next.next.val + (isSecondNumMorethan10 ? 1 : 0));
            }
            firstNode.next = secondNode;
            firstNode.next.next = thirdNode;
            return firstNode;
        }
    }
}
