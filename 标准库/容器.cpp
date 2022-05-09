//#include <iostream>
//#include <vector>
//#include <deque>
//using namespace std;
//
//class Person {
//public:
//	Person(string name, int age) {
//		this->m_Age = age;
//		this->m_Name = name;
//	}
//	string m_Name;
//	int m_Age;
//};
//
//void test01() {
//	Person p("aaa", 12);
//	Person p1("bbb", 23);
//	Person p2("ccc", 26);
//
//	vector<Person> v;
//	v.push_back(p);
//	v.push_back(p1);
//	v.push_back(p2);
//
//	for (vector<Person>::iterator it = v.begin(); it != v.end(); it++)
//	{
//		cout << "姓名：" << (*it).m_Name << ",Age=" << (*it).m_Age << endl;
//
//		cout << "姓名：" << it->m_Name << ",Age=" << it->m_Age << endl;
//	}
//
//}
//void test02() {
//	Person p("aaa", 12);
//	Person p1("bbb", 23);
//	Person p2("ccc", 26);
//	// 存放指针
//	vector<Person*> v;
//
//	// &p 表示放的是地址
//	v.push_back(&p);
//	v.push_back(&p1);
//	v.push_back(&p2);
//
//	for (vector<Person*>::iterator it = v.begin(); it != v.end(); it++)
//	{
//		cout << "姓名：" << (*it)->m_Name << ",age=>" << (*it)->m_Age << endl;
//	}
//}
//
///// <summary>
///// 容器嵌套容器
///// </summary>
//void test03() {
//	vector<vector<int>> v;
//
//	vector<int> v1;
//	vector<int> v2;
//	vector<int>v3;
//
//	v1.push_back(1);
//	v1.push_back(1);
//	v1.push_back(1);
//	v1.push_back(1);
//
//	v2.push_back(2);
//	v2.push_back(2);
//	v2.push_back(2);
//	v2.push_back(2);
//
//	v3.push_back(3);
//	v3.push_back(3);
//	v3.push_back(3);
//	v3.push_back(3);
//	v3.push_back(3);
//	v.push_back(v1);
//	v.push_back(v2);
//	v.push_back(v3);
//
//	for (vector<vector<int>>::iterator it = v.begin(); it != v.end(); it++)
//	{
//
//		for (vector<int>::iterator it1 = (*it).begin(); it1 != (*it).end(); it1++) {
//			cout << *it1;
//		}
//		cout << endl;
//	}
//}
//void test04() {
//	string s;
//	const char* str = "hello world";
//	string s1(str);
//	cout << "s1=" << s1 << endl;
//	char c = 'a';
//	string s2(4, c);
//	cout << "s2=>" << s2 << endl;
//
//	string s4;
//	s4.assign("hello C++");
//	cout << "s4=>" << s4 << endl;
//	string s5;
//	s5 = "我";
//	s5 += "爱玩游戏";
//	s5 += ':';
//	cout << s5 << endl;
//}
//void test05() {
//	vector<int> v1;
//	for (int i = 0; i < 10; i++)
//	{
//		v1.push_back(i);
//	}
//
//	// 区间的方式 传入迭代器
//	vector<int> v2(v1.begin(), v1.end());
//
//	// 第一个是个数
//	vector<int> v3(4, 100);
//	vector<int> v4(v3);
//
//	v4.insert(v4.begin() + 3, 10);
//	for (vector<int>::iterator it = v4.begin(); it != v4.end(); it++)
//	{
//		cout << *it <<" ";
//	}
//	cout << endl;
//}
//int main()
//{
//	test05();
//	system("pause");
//	return 0;
//	vector<int> vec;
//	int i;
//	cout << "vector size = " << vec.size() << endl;
//
//	for (i = 0; i < 5; i++)
//	{
//		vec.push_back(i);
//	}
//	cout << "extended vector size = " << vec.size() << endl;
//
//	for (int i = 0; i < 5; i++)
//	{
//		cout << "value of vec[" << i << "]=" << vec[i] << endl;
//
//	}
//
//
//	// 使用迭代器 iterator 访问值
//	//vector<int>::iterator v = vec.begin();
//	//while (v != vec.end())
//	//{
//	//	cout << "value of v=" << *v << endl;
//	//	v++;
//	//}
//
//	for (vector<int>::iterator it = vec.begin(); it != vec.end(); it++)
//	{
//		cout << "for 遍历" << *it << endl;
//	}
//
//	deque<int> deq;
//
//	for (int i = 0; i < 5; i++)
//	{
//		deq.push_back(i);
//	}
//
//	deque<int>::iterator d = deq.begin();
//
//	while (d != deq.end())
//	{
//		deq.pop_front();
//	}
//
//
//	system("pause");
//	return 0;
//}