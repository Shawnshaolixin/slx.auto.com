#include "boss.h"

Boss::Boss(int id, string name, int dId) {
	this->m_Id = id;
	this->m_Name = name;
	this->m_DeptId = dId;
}

void Boss::showInfo() {
	cout << "职工编号：" << this->m_Id << endl;
	cout << "职工姓名" << this->m_Name << endl;
	cout << "岗位" << this->getDeptName() << endl;
}
string Boss::getDeptName() {
	return "老板";
}