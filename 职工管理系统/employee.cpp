#include "employee.h"

Employee::Employee(int id, string name, int dId)
{
	this->m_Id = id;
	this->m_Name = name;
	this->m_DeptId = dId;
};
// ��ʾ������Ϣ
void Employee::showInfo()
{
	cout << "ְ����ţ�" << this->m_Id << endl;
	cout << "ְ������" << this->m_Name << endl;
	cout << "��λ" << this->getDeptName() << endl;
};
// ��ȡ��λ��Ϣ
string Employee::getDeptName()
{
	return string("��ͨԱ��");
};