using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A doubly linked list implementation supporting insertion, removal, replacement,
/// and both forward and reverse iteration.
/// </summary>
public class LinkedList : IEnumerable<int>
{
    private Node? _head; // Points to the first node
    private Node? _tail; // Points to the last node

    /// <summary>
    /// Insert a new node at the front (head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        Node newNode = new(value);

        if (_head is null) // Empty list
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Next = _head; // Link new node → old head
            _head.Prev = newNode; // Link old head → new node
            _head = newNode;      // Update head pointer
        }
    }

    /// <summary>
    /// Problem 1: Insert a new node at the back (tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        Node newNode = new(value);

        if (_tail is null) // Empty list
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail.Next = newNode; // Link old tail → new node
            newNode.Prev = _tail; // Link new node → old tail
            _tail = newNode;      // Update tail pointer
        }
    }

    /// <summary>
    /// Remove the first node (head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        if (_head == _tail) // Empty or single-node list
        {
            _head = null;
            _tail = null;
        }
        else if (_head is not null)
        {
            _head.Next!.Prev = null; // Disconnect second node from head
            _head = _head.Next;      // Update head pointer
        }
    }

    /// <summary>
    /// Problem 2: Remove the last node (tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        if (_head == _tail) // Empty or single-node list
        {
            _head = null;
            _tail = null;
        }
        else if (_tail is not null)
        {
            _tail.Prev!.Next = null; // Disconnect tail from previous node
            _tail = _tail.Prev;      // Update tail pointer
        }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value'.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr;
                    newNode.Next = curr.Next;
                    curr.Next!.Prev = newNode;
                    curr.Next = newNode;
                }
                return;
            }
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Problem 3: Remove the first node containing 'value'.
    /// </summary>
    public void Remove(int value)
    {
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                if (curr == _head)
                {
                    RemoveHead();
                }
                else if (curr == _tail)
                {
                    RemoveTail();
                }
                else
                {
                    curr.Prev!.Next = curr.Next;
                    curr.Next!.Prev = curr.Prev;
                }
                return; // Stop after first removal
            }
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Problem 4: Replace all occurrences of 'oldValue' with 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == oldValue)
            {
                curr.Data = newValue;
            }
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Forward iteration using foreach.
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head;
        while (curr is not null)
        {
            yield return curr.Data;
            curr = curr.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    /// <summary>
    /// Problem 5: Reverse iteration using foreach.
    /// </summary>
    public IEnumerable<int> Reverse()
    {
        var curr = _tail; // Start at the end
        while (curr is not null)
        {
            yield return curr.Data;
            curr = curr.Prev; // Move backwards
        }
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Helpers for testing
    public bool HeadAndTailAreNull() => _head is null && _tail is null;
    public bool HeadAndTailAreNotNull() => _head is not null && _tail is not null;
}

/// <summary>
/// Extension method for printing IEnumerable<int> neatly.
/// </summary>
public static class IntArrayExtensionMethods
{
    public static string AsString(this IEnumerable array)
    {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}