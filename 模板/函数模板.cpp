#include<iostream>
using namespace std;
#include "person.hpp"
#include"MyArray.hpp"
template<typename T>
void func(T& a, T& b) {


	T temp = b;
	b = a;
	a = temp;
}
template<class T>
void sort(T arr[], int len) {

	for (int i = 0; i < len; i++)
	{
		int max = i;
		for (int j = i + 1; j < len; j++)
		{
			if (arr[max] < arr[j])
			{
				max = j;
			}
		}
		if (max != i)
		{
			/*int temp = arr[max];
			arr[max] = arr[i];
			arr[i] = temp;*/

			func(arr[max], arr[i]);
		}
	}
}


void test01() {
	Person<string, int> p("张三", 12);
	p.showPerson();
}
void printInArr(MyArray<int>& arr);
void test02()
{
	MyArray<int> arr(5);
	for (int i = 0; i < 5; i++)
	{
		arr.Push_Back(i);
	}
	printInArr(arr);
 
}
void printInArr(MyArray<int>& arr) {
	for (int i = 0; i < arr.getSize(); i++)
	{
		cout << "打印数组：" << arr[i] << endl;
	}
}
int main()
{


	test02();

	test01();
	char arrc[] = { 'a','b','c' };
	char arr[] = "ebaiof";

	sort<char>(arr, 6);

	for (size_t i = 0; i < 6; i++)
	{
		cout << "i=>" << arr[i] << endl;
	}

	int arrint[] = { 3,4,5,7,3,1,2,3,4,7,8,1,2 };
	int len = sizeof(arrint) / sizeof(arrint[0]);
	sort(arrint, len);
	for (size_t i = 0; i < len; i++)
	{
		cout << "j=>" << arrint[i] << endl;
	}
	float a = 10;
	float b = 20;
	func<float>(a, b);
	cout << "a=>" << a << "b=>" << b << endl;
	int e = 30;
	int f = 50;
	func<int>(e, f);
	cout << "e=>" << e << ",f=>" << f << endl;
	system("pause");
	return 0;
}