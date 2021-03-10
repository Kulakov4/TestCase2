1. �������� �������, ������� ����������� ������ � ������� ������ � ����� (����� �������, �������� ���� ������� public int RomanToInt(string s)). ������� ����� �� ������ 3000.
2. ��������� ������������������ ��������� ��������� � ������������ ��������� ((1+3)()(4+(3-5)))
3. ����������� ���������� ������ � �������� �������, ���������������� ���, �.�. ���������� ������� ��������� �� ��������.

public interface DoubleLinkedNode<T>
{
	T Value { get; set; }
	DoubleLinkedNode<T> Next { get; set; }
	DoubleLinkedNode<T> Prev { get; set; }
}

public interface DoubleLinkedList<T>
{
	DoubleLinkedNode<T> First { get; set; }
	DoubleLinkedNode<T> Last { get; set; }
	void Reverse();
	//insert new DoubleLinkedListNode with given value at the start of the list
	void AddFirst(T value);
	//insert new DoubleLinkedListNode with given value at the end of the list
	void AddLast(T value);
}

��� ������� ������ ���� ������������ ����-�������.