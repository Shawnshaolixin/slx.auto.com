#include "boss.h"

Boss::Boss(int id, string name, int dId) {
	this->m_Id = id;
	this->m_Name = name;
	this->m_DeptId = dId;
}

void Boss::showInfo() {
	cout << "ְ����ţ�" << this->m_Id << endl;
	cout << "ְ������" << this->m_Name << endl;
	cout << "��λ" << this->getDeptName() << endl;
}
string Boss::getDeptName() {
	return "�ϰ�";
}