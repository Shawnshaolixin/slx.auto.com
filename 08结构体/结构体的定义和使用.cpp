#include <iostream>
using namespace std;
#include <string>
#include <ctime>
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
	struct Student arr_student[5];
};
void print(const Student* s) {
	cout << s->age << endl;
}
void allocateSpace(struct Teacher tArr[], int len)
{
	for (int i = 0; i < len; i++)
	{
		tArr[i].age = 10;
		tArr[i].id = i;
		tArr[i].name = "��ʦ";
		int stu_len = sizeof(tArr[i].arr_student) / sizeof(tArr[i].arr_student[0]);
		for (int j = 0; j < stu_len; j++)
		{
			tArr[i].arr_student[j].age = 222;
			tArr[i].arr_student[j].name = "ѧ��";
			int random = rand() % 61 + 40;
			tArr[i].arr_student[j].score = random;
		}
	}

	for (size_t i = 0; i < len; i++)
	{
		cout << "��" << i << "����ʦ�������ǣ�" << tArr[i].name << endl;
		int stu_len = sizeof(tArr[i].arr_student) / sizeof(tArr[i].arr_student[0]);
		cout << "ta��ѧ����" << stu_len << "��" << endl;
		for (int j = 0; j < stu_len; j++)
		{
			cout << "ѧ�������֣�" << tArr[i].arr_student[j].name << "��������" << tArr[i].arr_student[j].score << endl;
		}
	}
};

// 2.1 struct Student s1;
// 2.2 struct Student s2 ={};
// 2.3 �ڶ���ṹ��ʱ˳�㴴���ṹ�����
int main()
{
	srand((unsigned int)time(NULL));
	struct Teacher tArr[3];
	allocateSpace(tArr, sizeof(tArr) / sizeof(tArr[0]));

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