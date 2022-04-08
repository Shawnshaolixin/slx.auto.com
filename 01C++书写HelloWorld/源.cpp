#include <iostream>
using namespace std;


int main2()
{
	// 输出 Hello World;
	const int b = 20;

	cout << "Hello World" << endl;
	auto a = 10;
	cout << "a=" << a << endl;

	int arr[5];
	arr[0] = 10;
	cout << arr[0] << endl;
	int arr1[2] = { 1,3 };
	int arr3[] = { 1,2,6,4,5 };
	cout << sizeof(arr3) << endl;
	cout << sizeof(arr[0]) << endl;
	cout << "count=" << sizeof(arr3) / sizeof(arr[0]) << endl;
	cout << "地址：" << (int)arr3 << endl;
	cout << "第一个元素的首地址" << (int)&arr3[1] << endl;
	int length = sizeof(arr3) / sizeof(int);
	int max = 0;
	for (int i = 0; i < length; i++)
	{
		if (arr3[i] > max)
		{
			max = arr3[i];
		}
	}
	for (int i = 0; i < length / 2; i++)
	{
		int temp = arr3[i];
		arr3[i] = arr3[length - i - 1];
		arr3[length - i - 1] = temp;
	}
	for (int i = 0; i < length; i++)
	{
		cout << "i=" << i << " value=" << arr3[i] << endl;
	}
	cout << "最大值：" << max << endl;
	system("pause");

	return 0;
}