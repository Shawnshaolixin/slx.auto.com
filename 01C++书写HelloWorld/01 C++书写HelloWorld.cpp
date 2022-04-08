#include <iostream>
using namespace std;

//常量的定义方式有两种，
// 1. 宏常量
// 2.coust 修饰的变量

#define day 7
int main1()
{
	// 输出 Hello World;
	const int b = 20;
 
	cout << "Hello World" << endl;
	auto a = 10;
	cout << "a=" << a << endl;
	cout << "day=" << day << endl;
	system("pause");

	return 0;
}