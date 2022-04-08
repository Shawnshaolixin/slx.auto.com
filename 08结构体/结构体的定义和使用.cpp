#include <iostream>
using namespace std;
#include <string>
struct Student
{
	// 成员列表
	string name;
	int age;
	int score;
}s3;
// 1.创建学生数据类型
// 2.通过学生数据类型创建具体学生
struct Teacher {
	int id;
	string name;
	int age;
	struct Student student;
};
void print(const Student* s) {
	cout << s->age << endl;
}
// 2.1 struct Student s1;
// 2.2 struct Student s2 ={};
// 2.3 在定义结构体时顺便创建结构体变量
int main()
{

	struct Student s1;
	s1.name = "张三";
	s1.age = 16;
	s1.score = 100;
	cout << "姓名：" << s1.name << "age:" << s1.age << "score:" << s1.score << endl;


	const struct  Student s2 = { "李四",18,30 };

	cout << "姓名：" << s2.name << "age:" << s2.age << "score:" << s2.score << endl;


	s3.name = "王五";
	s3.age = 20;
	s3.score = 202;
	cout << "姓名：" << s3.name << "age:" << s3.age << "score:" << s3.score << endl;



	struct Student arr[3] = {
		{"11111",12,12},
		{"22222222",12,12},
		{"3333333",12,12}
	};

	int len = sizeof(arr) / sizeof(arr[0]);
	for (int i = 0; i < len; i++)
	{
		cout << "姓名：" << arr[i].name << ",age=" << arr[i].age << ",score:" << arr[i].score << endl;
	}

	Student* p = &s3;

	Student* pList = arr; //指向的是第一个元素  的地址
	cout << p->name << p->age << p->score << endl;

	for (int i = 0; i < len; i++)
	{
		cout << pList->name << endl;
		pList++;
	}


	system("pause");
	return 0;
}