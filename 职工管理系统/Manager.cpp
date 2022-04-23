
#include "manager.h"

Manager::Manager(int id, string name, int dId) {
	this->m_Id = id;
	this->m_Name = name;
	this->m_DeptId = dId;
}
void Manager::showInfo() {
	cout << "职工编号：" << this->m_Id << endl;
	cout << "职工姓名：" << this->m_Name << endl;
	cout << "岗位：" << this->getDeptName() << endl;
}
string Manager::getDeptName() {
	return "经理";
}
