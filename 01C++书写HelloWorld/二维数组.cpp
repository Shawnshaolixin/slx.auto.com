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
/// ð������
/// </summary>
/// <param name="arr"></param>
/// <param name="len"></param>
void bubbleSort(int* arr, int len)
{
	for (int i = 0; i < len - 1; i++)
	{
		for (int j = 0; j < len - i - 1; j++)
		{
			// ��� j>j+1;
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
		cout << "����=��" << arr01[i] << endl;
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


	// 1.����ָ��

	int  a = 10;

	int* p;
	p = &a;
	cout << "a  �ĵ�ַ��" << &a << endl;
	cout << "ָ��pΪ��" << p << endl;

	// 2.ʹ��ָ��
	// ����ͨ�������õķ�ʽ
	cout << "*p=" << *p << endl;

	// ָ�� 32λ����ϵͳ ռ��4���ֽ�  64λ ռ��8���ֽ�
	cout << "pվ���ڴ��С��" << sizeof(p) << endl;

	// ��ָ�� ����ʼ��ָ����� //��ָ�벻���Է��� 0-255�ڴ��� ϵͳռ��

	//int* p1 = NULL;

	//  *p1 = 10;

	// Ұָ�룬�ڳ����б������Ұָ��
	int b = 40;
	//int* p2 = (int*)0X0001;
	//cout << *p2 << endl;

	//1. const ����ָ��  ����ָ�룺�ص㣺ָ���ָ������޸ģ�����ָ��ָ���ֵ�������޸�
	const int* p5 = &a;
	// *p5 = 40; // ���ﱨ����
	p5 = &b;

	//2.const ���εĳ�����--ָ�볣��

	int* const p6 = &a;
	// �ص� ��ָ���ָ�򲻿��Ըģ�ָ���ֵ ���Ը�


	//3. const ������ָ�� �����γ���
	const int* const p8 = &a;
	// �ص�i:ָ��ָ���ֵ�����Ըģ�ָ���ֵҲ�����Ը�



	int arr12[10] = { 1,2,3,4,5,6,7,8,9,10 };
	cout << "��һ��Ԫ��Ϊ1��" << arr12[0] << endl;

	int* p9 = arr12;
	cout << "��һ��Ԫ��Ϊ2��" << *p9 << endl;
	p9++; // ��ָ�������� 4���ֽ�
	cout << "����ָ����ʵڶ���Ԫ�أ�" << *p9 << endl;
	int* p10 = arr12;
	for (int i = 0; i < 10; i++)
	{
		cout << *p10++ << endl;
	}
	system("pause");
	return 0;
}
