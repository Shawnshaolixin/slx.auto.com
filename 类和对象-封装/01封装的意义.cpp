#include <iostream>
using namespace std;

const double PI = 3.14;

class Point {
private:
	int m_X;
	int m_Y;
public:
	void setX(int x) {
		m_X = x;
	}
	void setY(int y) {
		m_Y = y;
	}
	int getX() {
		return m_X;
	}
	int getY() {
		return m_Y;
	}

};
class Circle {


private:
	int m_R;
	Point m_Center;
public:
	void setR(int r) {
		m_R = r;
	}
	void setCenter(Point& p) {
		m_Center = p;
	}
	int GuanXi(Point& p1) {
		auto value = (p1.getX() - m_Center.getX()) * (p1.getX() - m_Center.getX()) + (p1.getY() - m_Center.getY()) * (p1.getY() - m_Center.getY());
		if (value > m_R * m_R)
		{
			cout << "��Բ���" << endl;
		}
		else if (value < m_R * m_R)
		{
			cout << "��Բ���" << endl;
		}
		else {
			cout << "��Բ��" << endl;
		}
		return 0;
	}
	//����Ȩ�� ����Ȩ��


	//// ����
	//// �뾶
	//int m_r;

	//// ��ȡԲ���ܳ�
	//double calcZC() {
	//	return 2 * PI * m_r;
	//}

};

/// <summary>
/// ѧ����
/// </summary>
class Student {
	int m_age;
private:
	// ��Ա���� 
	string m_Name;
	int m_Id;
public:
	// ��Ϊ  ��Ա
	void showStudent() {
		cout << "������" << m_Name << ",ѧ�ţ�" << m_Id << endl;
	}
	void setName(string name) {
		if (name == "����")
		{
			cout << "���������δ� ������ֵ" << endl;
			return;
		}
		m_Name = name;
	}
	string getName() {
		return m_Name;
	}
	void setId(int id) {
		m_Id = id;
	}
	int getId() {
		return m_Id;
	}
};
/// <summary>
/// 1.�������3�����캯��
/// </summary>
class Person {

public:
	int age;
	Person(int _age) : age(_age) {
		cout << "���캯��ִ����" << endl;
	}

	// �������캯�� �༭��Ĭ�ϴ���
	Person(const Person& p) {
		// 
		age = p.age;
	}
	~Person()
	{
		cout << "��������ִ����" << endl;
	}
};
class Cube {
private:
	int m_L;
	int m_W;
	int m_H;
public:
	void setL(int l) {
		m_L = l;
	}
	int getL() {
		return m_L;
	}
	void setW(int w) {
		m_W = w;
	}
	int getW() {
		return m_W;
	}
	void setH(int h) {
		m_H = h;
	}
	int getH() {
		return m_H;
	}
	int getArea() {
		return 2 * (m_L * m_H + m_L * m_W + m_H * m_L);
	}
	int getTiJi() {
		return m_L * m_W * m_H;
	}
	/// <summary>
	/// �Ƿ�������
	/// </summary>
	/// <param name="cube"></param>
	/// <returns></returns>
	bool isSame(Cube& cube) {
		return cube.getH() == m_H && cube.getW() == m_W && cube.getL() == m_L;
	}
};
bool isSame(Cube& c1, Cube& c2) {
	return c1.getH() == c2.getH() && c1.getL() == c2.getL() && c1.getW() == c2.getW();
}
void test01() {

	// 1.���ŷ�
	Person person(10);
	Person p3(person);

	// ����Ǻ������� ���Բ��ᴴ������
//	Person p1();

	// 2.��ʾ��
	Person  p4 = Person(10);
	Person p5 = Person(p4);

	// Person(10)//��������
}
class A {
	// ��Ա�����ͳ�Ա�����Ƿֿ��洢��


	static	int a_course;
	int func() {
		return 0;
	}

public:
	A(int a_age) {
		this->a_age = a_age;
	}
	int a_age;
	A Add_age(A& a) {
		this->a_age += a.a_age;
		return *this;
	}
	// �������캯�� �༭��Ĭ�ϴ��� ţ��
	A(const A& a) {
		// 
		cout << "11111�������캯��ִ����" << endl;;
		a_age = a.a_age;
	}
};
int A::a_course = 10;
int main() {
	A ccc(12);
	cout << "�ն���ռ�����ֽڣ�" << sizeof(ccc) << endl;
	cout << "�����䣺" << ccc.a_age << endl;
	cout << "�����䣺" << ccc.Add_age(ccc).Add_age(ccc).Add_age(ccc).a_age << endl;

	//test01();
	//// ʵ���� 
	//Circle c1;
	//c1.m_r = 10;
	//cout << "Բ���ܳ���" << c1.calcZC() << endl;
	Circle c1;
	c1.setR(2);
	Point p;
	p.setX(0);
	p.setY(0);
	c1.setCenter(p);

	Point p3;
	p3.setX(1);
	p3.setY(0);
	c1.GuanXi(p3);


	Student s1;

	s1.setId(1);
	s1.setName("����");
	s1.getId();



	Cube c;
	c.setH(10);
	c.setL(10);
	c.setW(10);
	cout << "�����" << c.getArea() << ",�����" << c.getTiJi() << endl;

	Cube cube;
	cube.setH(10);
	cube.setL(10);
	cube.setW(101);
	cout << "����Cube �Ƿ����" << isSame(c, cube) << endl;
	cout << "����Cube �Ƿ����" << cube.isSame(c) << endl;
	system("pause");
}