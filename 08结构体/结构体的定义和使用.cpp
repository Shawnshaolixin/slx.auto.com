#include <iostream>
using namespace std;
#include <string>
struct Student
{
	// ��Ա�б�
	string name;
	int age;
	int score;
}s3;
// 1.����ѧ����������
// 2.ͨ��ѧ���������ʹ�������ѧ��
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
// 2.3 �ڶ���ṹ��ʱ˳�㴴���ṹ�����
int main()
{

	struct Student s1;
	s1.name = "����";
	s1.age = 16;
	s1.score = 100;
	cout << "������" << s1.name << "age:" << s1.age << "score:" << s1.score << endl;


	const struct  Student s2 = { "����",18,30 };

	cout << "������" << s2.name << "age:" << s2.age << "score:" << s2.score << endl;


	s3.name = "����";
	s3.age = 20;
	s3.score = 202;
	cout << "������" << s3.name << "age:" << s3.age << "score:" << s3.score << endl;



	struct Student arr[3] = {
		{"11111",12,12},
		{"22222222",12,12},
		{"3333333",12,12}
	};

	int len = sizeof(arr) / sizeof(arr[0]);
	for (int i = 0; i < len; i++)
	{
		cout << "������" << arr[i].name << ",age=" << arr[i].age << ",score:" << arr[i].score << endl;
	}

	Student* p = &s3;

	Student* pList = arr; //ָ����ǵ�һ��Ԫ��  �ĵ�ַ
	cout << p->name << p->age << p->score << endl;

	for (int i = 0; i < len; i++)
	{
		cout << pList->name << endl;
		pList++;
	}


	system("pause");
	return 0;
}