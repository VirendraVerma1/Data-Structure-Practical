using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleLinkedList : MonoBehaviour
{
    string LikedInsource = "https://www.geeksforgeeks.org/linked-list-set-1-introduction/";

    //linked list
    //Linked List is a linear data structure. Unlike arrays, linked list elements are not stored at a contiguous location; the elements are linked using pointers.


    //why linked list
    //1. array has upper limit but linked list is not
    //2. if we have to insert element in the starting, in array we have to shift all the element but in linked list we can add easily

    //important points
    //1. array is taken as a static data structure(residing in Data or Stack section) while linked list is taken as a dynamic data(residing in Heap section)


    public SampleNode head;

    void Start()
    {
        SimpleLinkedListInitializeManually();
        print("Finalized");
    }

    //list have one head then refer to next one
    void SimpleLinkedListInitializeManually()
    {
        head = new SampleNode(1);//creating very first element so we use head
        SampleNode first = new SampleNode(2);
        SampleNode second = new SampleNode(3);

        head.next = first;//add reference to the other one in next SampleNode class
        first.next = second;//then in the first SampleNode class we refer to second one

        pushInFront(10);
        pushInFront(4);
        pushInFront(1);
        insertAfter(first,20);
        append(100);
        deleteusingkey(3);
        deleteusingposition(2);
        SwapNumber(1,20);
        reverse();
        printList();
        print("Length = " + getLength());
        print("Recursive Length = " + getCountRec(head));

        //mergetwolinkedList();
    }

    void printList()
    {
        SampleNode n = head;
        while (n != null)
        {
            print(n.data);
            n = n.next;
        } 
    }

    void pushInFront(int data) //time complexity of new SampleNode is O(1) 
    {
        SampleNode newSampleNode = new SampleNode(data);
        newSampleNode.next = head;
        head = newSampleNode;
    }

    void insertAfter(SampleNode prev_SampleNode, int data)//complexity O(1) 
    {
        if (prev_SampleNode == null)
            print("previous SampleNode is not present");

        SampleNode new_SampleNode = new SampleNode(data);
        new_SampleNode.next = prev_SampleNode.next;
        prev_SampleNode.next = new_SampleNode;
    }

    void append(int data)//complexity  O(n)
    {
        //creating new SampleNode
        SampleNode new_SampleNode = new SampleNode(data);

        //check head if null then make new SampleNode as a head
        if(head==null)
        {
            head = new_SampleNode;
            return;
        }

        //initialize new SampleNode next to null
        new_SampleNode.next = null;

        //initialize last SampleNode to head
        SampleNode last_SampleNode = head;

        while(last_SampleNode.next !=null)
        {
            last_SampleNode = last_SampleNode.next;
        }

        
        last_SampleNode.next = new_SampleNode;
        return;
    }

    void deleteusingkey(int key)
    {
        SampleNode temp, previous;
        temp = head;
        previous = null;

        //check if it is not a head
        if(temp!=null && temp.data==key)
        {
            head = temp.next;//just unlink the data
            return;
        }

        //we will automatically get the SampleNode in temp after the whole loop completion
        while(temp!=null && temp.data!=key)
        {
            previous = temp;
            temp = temp.next;
        }

        if(temp==null)//means not found the SampleNode having key
        {
            return;
        }

        previous.next = temp.next;//unlinking the temp SampleNode
    }

    void deleteusingposition(int pos)
    {
        SampleNode temp = head;

        //check if head is not null
        if(temp==null)
        {
            return;
        }

        //chek if position is not 0
        if(pos==0)
        {
            head = temp.next;
            return;
        }

        //means pos is not 0 then use loop
        int index = 0;
        bool flag = true;

        while(flag&& temp.next!=null)
        {
            if (index == pos-2)
                flag = false;
            temp = temp.next;
            
            index++;
        }

        //check if that SampleNode is not null
        if( temp.next == null || temp.next.next == null)
        {
            return;
        }

        //print(temp.data+"data" +temp.next.next.data);
        //delete that SampleNode
        temp.next = temp.next.next;
    }

    int getLength()
    {
        SampleNode n = head;
        int counter = 0;
        while(n!=null)
        {
            counter++;
            n = n.next;
        }
        return counter;
    }

    int getCountRec(SampleNode SampleNode)
    {
        // Base case
        if (SampleNode == null)
            return 0;

        // Count is this SampleNode plus rest of the list
        return 1 + getCountRec(SampleNode.next);
    }

    void SwapNumber(int x, int y)
    {
        // Nothing to do if x and y are same
        if (x == y)
            return;

        // Search for x (keep track of prevX and CurrX)
        SampleNode prevX = null, currX = head;
        while (currX != null && currX.data != x)
        {
            prevX = currX;
            currX = currX.next;
        }

        // Search for y (keep track of prevY and currY)
        SampleNode prevY = null, currY = head;
        while (currY != null && currY.data != y)
        {
            prevY = currY;
            currY = currY.next;
        }

        // If either x or y is not present, nothing to do
        if (currX == null || currY == null)
            return;

        // If x is not head of linked list
        if (prevX != null)
            prevX.next = currY;
        else // make y the new head
            head = currY;

        // If y is not head of linked list
        if (prevY != null)
            prevY.next = currX;
        else // make x the new head
            head = currX;

        // Swap next pointers
        SampleNode temp = currX.next;
        currX.next = currY.next;
        currY.next = temp;
    }

    void reverse()
    {
        SampleNode temp_head = head;

        SampleNode prev = null;
        SampleNode current = head;
        SampleNode next=null;
        while(current!=null)
        {
            next = current.next;
            current.next = prev;
            prev = current;
            current = next;
            
        }
        head = prev;
    }

    void mergetwolinkedList()
    {
        //linked list 1
        SampleLinkedList newList1 = new SampleLinkedList();
        newList1.head = new SampleNode(1);
        SampleNode firstList1 = new SampleNode(2);
        SampleNode firstList2 = new SampleNode(3);
        SampleNode firstList3 = new SampleNode(4);
        newList1.head.next = firstList1;
        firstList1.next = firstList2;
        firstList2.next = firstList3;

        //linked list 1
        SampleLinkedList newList2 = new SampleLinkedList();
        newList2.head = new SampleNode(10);
        SampleNode secondList1 = new SampleNode(20);
        SampleNode secondList2 = new SampleNode(30);
        SampleNode secondList3 = new SampleNode(40);
        newList2.head.next = secondList1;
        secondList1.next = secondList2;
        secondList2.next = secondList3;



        //merge
        SampleNode temp = newList1.head;
        while(temp.next!=null)
        {
            temp = temp.next;
        }

        temp.next = newList2.head;


        //for printing
        print("Merging two SampleNodes");
        SampleNode newTemp = newList1.head;
        while(newTemp!=null)
        {
            print(newTemp.data);
            newTemp = newTemp.next;
        }
    }
}


//it is like bean class which create multiple small classes having their own reference in data
public class SampleNode  //SampleNode class
{
    public int data;   //reference id
    public SampleNode next;  //its class

    public SampleNode(int d) //constructor that stores its single value in data
    {
        data = d;
        next = null;
    }
}
