#include "employee.h"

Employee::Employee(int id, string name, int dId)
{
	this->m_Id = id;
	this->m_Name = name;
	this->m_DeptId = dId;
};
// 显示个人信息
void Employee::showInfo()
{
	cout << "职工编号：" << this->m_Id << endl;
	cout << "职工姓名" << this->m_Name << endl;
	cout << "岗位" << this->getDeptName() << endl;
};
// 获取岗位信息
string Employee::getDeptName()
{
	return string("普通员工");
};