//#include<iostream>
//#include <vector>
//#include <deque>
//#include<algorithm>
//#include <stack>
//#include <queue>
//#include <list>
//using namespace std;
//
//
//class Person {
//public:
//	Person(string name, int score) {
//		this->m_Score = score;
//		this->m_Name = name;
//	}
//	string m_Name;
//	int m_Score;
//};
//void showScore(vector<Person>& v) {
//	for (vector<Person>::iterator it = v.begin(); it != v.end(); it++)
//	{
//		cout << "姓名：" << it->m_Name << ",分数=" << it->m_Score << endl;
//	}
//}
//
//void setScore(vector<Person>& v) {
//	for (vector<Person>::iterator it = v.begin(); it != v.end(); it++)
//	{
//		deque<int> d;
//		for (int i = 0; i < 10; i++)
//		{
//			int score = rand() % 41 + 60; // 60-100 之间
//			d.push_back(score);
//
//		}
//		// 排序
//		sort(d.begin(), d.end());
//		// 去掉最高分和最低分
//		d.pop_back();
//		d.pop_front();
//
//		int sum = 0;
//
//		for (deque<int>::iterator it = d.begin(); it != d.end(); it++)
//		{
//			sum += *it;
//		}
//		int avg = sum / d.size();
//		it->m_Score = avg;
//	}
//
//}
//void createPerson(vector<Person>& v) {
//	string nameSeed = "ABCDE";
//	for (size_t i = 0; i < 5; i++)
//	{
//		string name = "选手";
//		name += nameSeed[i];
//		int score = 0;
//		Person p(name, score);
//		v.push_back(p);
//	}
//}
//void test01() {
//
//	vector<Person> v;
//	createPerson(v);
//	setScore(v);
//	showScore(v);
//
//
//
//}
//
//void test02() {
//
//	stack<int> s;
//	s.push(10);
//	s.push(20);
//	s.push(30);
//
//	while (!s.empty())
//	{
//		cout << "栈顶元素为" << s.top() << endl;
//		s.pop();
//	}
//	cout << "栈大小size=" << s.size() << endl;
//
//}
//void test03() {
//	queue<int> q;
//	q.push(10);
//	q.push(20);
//	q.push(30);
//	while (!q.empty())
//	{
//		cout << "队列里面的元素：" << q.front() << endl;
//		q.pop();
//	}
//	cout << "队列的size=" << q.size() << endl;
//}
//void printList(list<int>& l) {
//	for (list<int>::iterator it = l.begin(); it != l.end(); it++)
//	{
//		cout << "l=>" << *it << " ";
//	}
//	cout << endl;
//}
//void test04() {
//	list<int> l1;
//	l1.push_back(10);
//	l1.push_back(20);
//	l1.push_back(30);
//	l1.push_back(40);
//
//	printList(l1);
//	list<int> l2(l1.begin(), l1.end());
//	printList(l2);
//	list<int> l3(l2);
//
//	printList(l3);
//	list<int> l4(10, 20);
//	printList(l4);
//}
//void main()
//{
//	// test01();
//	//test02();
//	//test03();
//	test04();
//
//	system("pause");
//}