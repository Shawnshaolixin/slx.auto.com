#include <iostream>
using namespace std;


class Person {
	// 友元
	friend	ostream& operator<<(ostream& cout, Person& p1);
public:
	Person(string age1) {
		age = age1;
	}
	Person(const Person& a) {
		// 
		cout << "11111拷贝构造函数执行了" << endl;;

	}


public:
	string age;


};
// 顺序害死人
ostream& operator<<(ostream& cout, Person& p1) {
	cout << p1.age;
	return cout;
}
Person& test01(Person* p) {

	Person& temp_p = *p;
	return temp_p;
}
int test02(Person& p) {
	return 0;
}
int main() {


	int a = 10;
	cout << ++a << endl;
	cout << a << endl;
	int b = 20;
	cout << b++ << endl;
	cout << b << endl;
	cout << "hello" << endl;

	Person p("123");
	test01(&p);

	cout << p << endl;
	system("pause");

	return 0;
}