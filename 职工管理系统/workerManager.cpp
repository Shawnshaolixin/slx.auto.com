#include "workerManager.h"
#include "employee.h"
#include "manager.h"
#include "boss.h"
#include <cstring>
WorkerManager::WorkerManager() {

	// �ļ�������
	ifstream ifs;
	ifs.open(FILENAME, ios::in);

	// �ļ�������
	if (!ifs.is_open()) {
		cout << "�ļ�������" << endl;
		this->m_EmpNum = 0;
		this->m_EmpArray = NULL;

		this->m_FileIsEmpty = true;
		ifs.close();
		return;
	}
	else {

		if (ifs.eof()) {
			cout << "��һ�����ļ�" << endl;
		}
		int count = this->get_EmpNum();
		this->m_EmpArray = new Worker * [count];

		m_FileIsEmpty = count == 0;
		this->m_EmpNum = count;
		init_Emp();

	}
	ifs.close();

}

int WorkerManager::is_Exist(int id) {

	if (this->m_FileIsEmpty)
	{
		return -1;
	}
	for (int i = 0; i < this->m_EmpNum; i++)
	{
		if (this->m_EmpArray[i]->m_Id == id)
		{

			return  i;
		}
	}
	return -1;

}
void WorkerManager::delete_Emp() {
	if (this->m_FileIsEmpty)
	{
		cout << "�ļ�Ϊ������ �޷�ɾ��" << endl;
		return;
	}
	cout << "������Ҫɾ��Ա����id" << endl;
	int id;
	cin >> id;
	int index = is_Exist(id);
	if (index == -1)
	{
		cout << "û�в鵽���� �޷�ɾ��" << endl;
		return;
	}

	while (index < this->m_EmpNum)
	{
		this->m_EmpArray[index] = m_EmpArray[index + 1];
		index++;
	}
	this->m_EmpNum--;
	Save();
}
/// <summary>
/// ��ʾְ��
/// </summary>
void WorkerManager::showWorkerList() {

	if (this->m_FileIsEmpty)
	{
		cout << "�ļ�Ϊ������" << endl;
		return;
	}
	for (int i = 0; i < this->m_EmpNum; i++)
	{
		this->m_EmpArray[i]->showInfo();
	}
	system("pause");
	system("cls");
}
void WorkerManager::edit_Emp() {
	int id;
	cout << "������Id" << endl;
	cin >> id;
	int index = is_Exist(id);
	if (index == -1)
	{
		cout << "û�в鵽���� �޷�ɾ��" << endl;
		return;
	}
	m_EmpArray[index]->showInfo();
	string name;
	cout << "����������";

	cin >> name;
	this->m_EmpArray[index]->m_Name = name;
	cout << "�޸ĳɹ���" << endl;
	m_EmpArray[index]->showInfo();
	system("pause");
	system("cls");
	Save();
}
void WorkerManager::find_Emp() {
	int id;
	cout << "������Id" << endl;
	cin >> id;
	int index = is_Exist(id);
	if (index == -1)
	{
		cout << "û�в鵽���� " << endl;
		return;
	}
	m_EmpArray[index]->showInfo();
}
void WorkerManager::clean_Emp() {
	ofstream ofs(FILENAME, ios::trunc);//�������ɾ���ļ������´���
	ofs.close();

	if (this->m_EmpArray != NULL)
	{
		for (int i = 0; i < this->m_EmpNum; i++)
		{
			if (this->m_EmpArray[i] != NULL)
			{
				delete this->m_EmpArray[i];
			}
		}
		this->m_EmpNum = 0;
		delete[] this->m_EmpArray;
		this->m_EmpArray = NULL;
		this->m_FileIsEmpty = true;
	}
	cout << "���ok" << endl;
}
void WorkerManager::sort_Emp() {

	if (this->m_EmpNum <= 0)
	{
		cout << "ô������ ��ɶ ?" << endl;
		return;
	}
	cout << "��ѡ�� �����ǽ���" << endl;
	int type;
	cout << "1:����2������" << endl;
	cin >> type;
	if (type == 1)
	{

		for (int i = 0; i < this->m_EmpNum; i++)
		{
			for (int j = 0; j < this->m_EmpNum - i - 1; j++)
			{
				if (this->m_EmpArray[j]->m_Id < this->m_EmpArray[j + 1]->m_Id)
				{
					Worker* worker = this->m_EmpArray[j + 1];
					m_EmpArray[j + 1] = m_EmpArray[j];
					m_EmpArray[j] = worker;
				}
			}
		}
		Save();
	}

}
void WorkerManager::init_Emp() {
	// �ļ�������
	ifstream ifs;
	ifs.open(FILENAME, ios::in);
	int id;
	string name;
	int dId;
	int index = 0;
	while (ifs >> id && ifs >> name && ifs >> dId)
	{
		Worker* worker = NULL;
		switch (dId) {
		case 1:
			worker = new Employee(id, name, dId);
		case 2:
			worker = new Manager(id, name, dId);
		case 3:
			worker = new Manager(id, name, dId);
		default:
			break;
		}

		m_EmpArray[index] = worker;
		index++;
	}
	ifs.close();
}
void WorkerManager::Show_Menu() {
	cout << "*******************************************" << endl;
	cout << "************ Welcome  *********************" << endl;
	cout << "************ 0.�˳�����ϵͳ  **************" << endl;
	cout << "************ 1.����ְ����Ϣ  **************" << endl;
	cout << "************ 2.��ʾְ����Ϣ  **************" << endl;
	cout << "************ 3.ɾ��ְ����Ϣ  **************" << endl;
	cout << "************ 4.�޸�ְ����Ϣ  **************" << endl;
	cout << "************ 5.����ְ����Ϣ  **************" << endl;
	cout << "************ 6.���ձ�������  **************" << endl;
	cout << "************ 7.��������ĵ�  **************" << endl;
	cout << "*******************************************" << endl;
	cout << endl;
}
void WorkerManager::ExitSystem() {

	cout << "��ӭ�´�ʹ��" << endl;
	system("pause");
	exit(0); // �˳�����
}
void WorkerManager::Add_Emp() {
	cout << "����������ְ������" << endl;
	int addNum = 0;
	cin >> addNum;
	if (addNum > 0)
	{
		//�����¿ռ��С
		int newSize = this->m_EmpNum + addNum;

		// �����¿ռ�
		Worker** newSpace = new Worker * [newSize];

		if (this->m_EmpArray != NULL)
		{
			for (int i = 0; i < this->m_EmpNum; i++)
			{
				// ��Ų������������ȥ
				newSpace[i] = this->m_EmpArray[i];
			}
		}
		// ���������
		for (int i = 0; i < addNum; i++)
		{
			int id;
			string name;
			int dSelect;

			cout << "�������" << i + 1 << " ��Ա���ı�ţ�" << endl;
			cin >> id;
			cout << "�������" << i + 1 << " ��Ա����������" << endl;
			cin >> name;
			cout << "��ѡ���ְ���ĸ�λ��" << endl;
			cout << "1 ��ͨԱ��" << endl;
			cout << "2 ����" << endl;
			cout << "3 �ϰ�" << endl;
			cin >> dSelect;
			Worker* worker = NULL;
			switch (dSelect) {
			case 1:
				worker = new Employee(id, name, 1);
			case 2:
				worker = new Manager(id, name, 2);
			case 3:
				worker = new Manager(id, name, 3);
			default:
				break;
			}
			newSpace[this->m_EmpNum + i] = worker;
		}

		// �ͷ�ԭ�еĿռ�
		delete[] this->m_EmpArray;
		this->m_EmpArray = newSpace;
		this->m_EmpNum = newSize;
		cout << "�ɹ����" << addNum << " ����Ա��" << endl;
		m_FileIsEmpty = false;
		this->Save();
	}
	else {
		cout << "��������" << endl;
	}
	system("pause");
	system("cls");
}

void WorkerManager::Save() {
	ofstream ofs;
	ofs.open(FILENAME, ios::out);//������ķ�ʽ�� --д�ļ�

	for (int i = 0; i < this->m_EmpNum; i++)
	{
		ofs << this->m_EmpArray[i]->m_Id << " "
			<< this->m_EmpArray[i]->m_Name << " "
			<< this->m_EmpArray[i]->m_DeptId << endl;
	}
	ofs.close();
}
int WorkerManager::get_EmpNum() {
	ifstream ifs;
	ifs.open(FILENAME, ios::in);
	int id;
	string name;
	int dId;
	int num = 0;
	while (ifs >> id && ifs >> name && ifs >> dId)
	{
		num++;
	}
	ifs.close();
	return num;
}
WorkerManager::~WorkerManager() {
	if (this->m_EmpArray != NULL)
	{
		delete[] this->m_EmpArray;
		this->m_EmpArray = NULL;
	}
}