#include <iostream>
using namespace std;
#include "sawp.h"
int add(int a, int b) {
	return a + b;
}
void swap01(int* p1, int* p2) {
	int temp = *p1;
	*p1 = *p2;
	*p2 = temp;
}
/// <summary>
/// 冒泡排序
/// </summary>
/// <param name="arr"></param>
/// <param name="len"></param>
void bubbleSort(int* arr, int len)
{
	for (int i = 0; i < len - 1; i++)
	{
		for (int j = 0; j < len - i - 1; j++)
		{
			// 如果 j>j+1;
			if (arr[j] > arr[j + 1])
			{
				int temp = arr[j];
				arr[j] = arr[j + 1];
				arr[j + 1] = temp;
			}
		}
	}
}
int main()
{

	int arr01[10] = { 2,3,7,6,5,8,9,1,4,7 };


	int len = sizeof(arr01) / sizeof(arr01[0]);


	bubbleSort(arr01, len);

	for (int i = 0; i < len; i++)
	{
		cout << "排序=》" << arr01[i] << endl;
	}









	swap(2, 3);
	int c1 = 10;
	int d = 20;
	swap01(&c1, &d);
	cout << "swap01= c = " << c1 << endl;
	cout << "swap02 = d= " << d << endl;
	int arr[2][3];
	arr[0][0] = 1;
	arr[0][1] = 2;
	arr[0][2] = 3;
	arr[1][0] = 1;
	arr[1][1] = 2;
	arr[1][2] = 3;

	int arr1[2][3] = {
		{1,2,3},
		{3,4,5}
	};
	int arr2[2][3]{
		1,2,3,
		3,4,5

	};
	int arr3[][3] = {
		1,2,3,
		4,5,6
	};
	int c = add(1, 5);
	cout << "result =>" << c << endl;


	// 1.定义指针

	int  a = 10;

	int* p;
	p = &a;
	cout << "a  的地址：" << &a << endl;
	cout << "指针p为：" << p << endl;

	// 2.使用指针
	// 可以通过解引用的方式
	cout << "*p=" << *p << endl;

	// 指针 32位操作系统 占用4个字节  64位 占用8个字节
	cout << "p站的内存大小：" << sizeof(p) << endl;

	// 空指针 ，初始化指针变量 //空指针不可以访问 0-255内存编号 系统占用

	//int* p1 = NULL;

	//  *p1 = 10;

	// 野指针，在程序中避免出现野指针
	int b = 40;
	//int* p2 = (int*)0X0001;
	//cout << *p2 << endl;

	//1. const 修饰指针  常量指针：特点：指针的指向可以修改，但是指针指向的值不可以修改
	const int* p5 = &a;
	// *p5 = 40; // 这里报错了
	p5 = &b;

	//2.const 修饰的常量，--指针常量

	int* const p6 = &a;
	// 特点 ：指针的指向不可以改，指向的值 可以改


	//3. const 既修饰指针 又修饰常量
	const int* const p8 = &a;
	// 特点i:指针指向的值不可以改，指向的值也不可以改



	int arr12[10] = { 1,2,3,4,5,6,7,8,9,10 };
	cout << "第一个元素为1：" << arr12[0] << endl;

	int* p9 = arr12;
	cout << "第一个元素为2：" << *p9 << endl;
	p9++; // 让指针向后便宜 4个字节
	cout << "利用指针访问第二个元素：" << *p9 << endl;
	int* p10 = arr12;
	for (int i = 0; i < 10; i++)
	{
		cout << *p10++ << endl;
	}
	system("pause");
	return 0;
}
