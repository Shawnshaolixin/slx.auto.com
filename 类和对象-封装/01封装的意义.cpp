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
			cout << "在圆外边" << endl;
		}
		else if (value < m_R * m_R)
		{
			cout << "在圆里边" << endl;
		}
		else {
			cout << "在圆上" << endl;
		}
		return 0;
	}
	//访问权限 公共权限


	//// 属性
	//// 半径
	//int m_r;

	//// 获取圆的周长
	//double calcZC() {
	//	return 2 * PI * m_r;
	//}

};

/// <summary>
/// 学生类
/// </summary>
class Student {
	int m_age;
private:
	// 成员属性 
	string m_Name;
	int m_Id;
public:
	// 行为  成员
	void showStudent() {
		cout << "姓名：" << m_Name << ",学号：" << m_Id << endl;
	}
	void setName(string name) {
		if (name == "张三")
		{
			cout << "张三是屏蔽词 不允许赋值" << endl;
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
/// 1.至少添加3个构造函数
/// </summary>
class Person {

public:
	int age;
	Person(int _age) : age(_age) {
		cout << "构造函数执行了" << endl;
	}

	// 拷贝构造函数 编辑器默认创建
	Person(const Person& p) {
		// 
		age = p.age;
	}
	~Person()
	{
		cout << "析构函数执行了" << endl;
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
	/// 是否和我相等
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

	// 1.括号法
	Person person(10);
	Person p3(person);

	// 这个是函数声明 所以不会创建对象
//	Person p1();

	// 2.显示法
	Person  p4 = Person(10);
	Person p5 = Person(p4);

	// Person(10)//匿名对象
}
class A {
	// 成员变量和成员函数是分开存储的


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
	// 拷贝构造函数 编辑器默认创建 牛逼
	A(const A& a) {
		// 
		cout << "11111拷贝构造函数执行了" << endl;;
		a_age = a.a_age;
	}
};
int A::a_course = 10;
int main() {
	A ccc(12);
	cout << "空对象占多少字节：" << sizeof(ccc) << endl;
	cout << "空年龄：" << ccc.a_age << endl;
	cout << "空年龄：" << ccc.Add_age(ccc).Add_age(ccc).Add_age(ccc).a_age << endl;

	//test01();
	//// 实例化 
	//Circle c1;
	//c1.m_r = 10;
	//cout << "圆的周长：" << c1.calcZC() << endl;
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
	s1.setName("张三");
	s1.getId();



	Cube c;
	c.setH(10);
	c.setL(10);
	c.setW(10);
	cout << "面积：" << c.getArea() << ",体积：" << c.getTiJi() << endl;

	Cube cube;
	cube.setH(10);
	cube.setL(10);
	cube.setW(101);
	cout << "两个Cube 是否相等" << isSame(c, cube) << endl;
	cout << "两个Cube 是否相等" << cube.isSame(c) << endl;
	system("pause");
}