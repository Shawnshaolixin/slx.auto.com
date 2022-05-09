#include<iostream>
#include <vector>
#include <map>
#include<functional>
#include <algorithm>
using namespace std;

#define CEHUA 0
#define MEISHU 1
#define YANFA 2


class Person {
public:
	Person(string name, int salary) {
		this->m_Name = name;
		this->m_Salary = salary;
	}
	string m_Name;
	int m_Salary;
};
void test01() {

}
void addPerson(vector<Person>& v) {

	string str = "ABCDEFGHJK";

	for (int i = 0; i < 10; i++)
	{
		string name = "员工";
		int salary = rand() % 10000 + 10000;
		name += str[i];
		Person p(name, salary);
		v.push_back(p);
	}
}
void showPerson(vector<Person>& v) {
	for (vector<Person>::iterator it = v.begin(); it != v.end(); it++)
	{
		cout << "打印员工：" << it->m_Name << " " << it->m_Salary << endl;
	}
}
void setGroup(multimap<int, Person>& m, vector<Person>& v) {

	for (vector<Person>::iterator it = v.begin(); it != v.end(); it++)
	{
		int depId = rand() % 3;
		m.insert(make_pair(depId, *it));
	}
}
void showPersonByGroup(multimap<int, Person>& m) {
	cout << "策划部门" << endl;

	multimap<int, Person>::iterator pos = m.find(CEHUA);
	int count = m.count(CEHUA);
	int index = 0;

	for (; pos != m.end() && index < count; pos++, index++)
	{
		cout << "姓名：" << pos->second.m_Name << " 工资:" << pos->second.m_Salary << endl;
	}
	cout << "美术部门" << endl;
	cout << "研发部门" << endl;

}
void test03() {
	negate<int> n;
	cout << n(50) << endl;
	plus<int> p;
	cout << p(10, 20) << endl;

	vector<int> v;
	v.push_back(02);
	v.push_back(022);
	v.push_back(022);
	v.push_back(32);
	sort(v.begin(), v.end(), greater<int>());
}
int main()
{
	test03();
	srand((unsigned int)time(NULL)); // 随机种子
	vector<Person> v;
	addPerson(v);
	//showPerson(v);
	multimap<int, Person> m;
	setGroup(m, v);

	showPersonByGroup(m);

	system("pause");
	return 0;
}