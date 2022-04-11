#include <iostream>
using namespace std;

int* func() {
	// 返回的是该类型的指针
	int* p = new int(10);
	return p;
}
void test02() {
	int* arr = new int[10];
	for (int i = 0; i < 10; i++)
	{
		arr[i] = 10;
	}
	// 释放一个数组
	delete[] arr;
}
void swap01(int a, int b) {
	int temp = a;
	a = b;
	b = temp;
}
void swap02(int* a, int* b) {
	int temp = *a;
	*a = *b;
	*b = temp;
}
void swap03(int& a, int& b) {
	int temp = a;
	a = b;
	b = temp;
}
int& test01() {
	int a = 10;
	return a;
}
// 常量引用 修饰形参，防止误操作
void showValue(const int& value) {

	cout << value << endl;
}
// 函数的默认参数
void func1(int a, int b, int c = 10) {
	a = b + a;
}
// 占位参数
void func2(int a, int) {
	cout << "1111111111111111111" << endl;
}
int main() {

	func2(10, 10);
	const int& ref1 = 10;

	int temp = 20;
	const int& ref2 = temp;
	int* p = func();
	cout << *p << endl;
	// 释放内存
	delete p;
	// cout << *p << endl;

	int a = 10;
	int b = 20;
	swap01(a, b);
	cout << "a=" << a << ",b=" << b << endl;
	swap02(&a, &b);
	cout << "a=" << a << ",b=" << b << endl;
	swap03(a, b);
	cout << "a=" << a << ",b=" << b << endl;
	//	int& b = a;

		/*b = 20;
		cout << "a=>" << a << endl;
		cout << "b=>" << b << endl;*/

		// 引用：给变量起别名,本质是 指针常量，一旦初始化后，就不可以发生改变
	system("pause");
	int& ref = test01();
	cout << ref << endl;
	cout << ref << endl;

	system("pause");
	return 0;
}