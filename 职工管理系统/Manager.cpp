
#include "manager.h"

Manager::Manager(int id, string name, int dId) {
	this->m_Id = id;
	this->m_Name = name;
	this->m_DeptId = dId;
}
void Manager::showInfo() {
	cout << "ְ����ţ�" << this->m_Id << endl;
	cout << "ְ��������" << this->m_Name << endl;
	cout << "��λ��" << this->getDeptName() << endl;
}
string Manager::getDeptName() {
	return "����";
}
