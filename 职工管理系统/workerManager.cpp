#include "workerManager.h"
#include "employee.h"
#include "manager.h"
#include "boss.h"
#include <cstring>
WorkerManager::WorkerManager() {

	// 文件不存在
	ifstream ifs;
	ifs.open(FILENAME, ios::in);

	// 文件不存在
	if (!ifs.is_open()) {
		cout << "文件不存在" << endl;
		this->m_EmpNum = 0;
		this->m_EmpArray = NULL;

		this->m_FileIsEmpty = true;
		ifs.close();
		return;
	}
	else {

		if (ifs.eof()) {
			cout << "有一个空文件" << endl;
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
		cout << "文件为不存在 无法删除" << endl;
		return;
	}
	cout << "请输入要删除员工的id" << endl;
	int id;
	cin >> id;
	int index = is_Exist(id);
	if (index == -1)
	{
		cout << "没有查到数据 无法删除" << endl;
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
/// 显示职工
/// </summary>
void WorkerManager::showWorkerList() {

	if (this->m_FileIsEmpty)
	{
		cout << "文件为不存在" << endl;
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
	cout << "请输入Id" << endl;
	cin >> id;
	int index = is_Exist(id);
	if (index == -1)
	{
		cout << "没有查到数据 无法删除" << endl;
		return;
	}
	m_EmpArray[index]->showInfo();
	string name;
	cout << "请输入姓名";

	cin >> name;
	this->m_EmpArray[index]->m_Name = name;
	cout << "修改成功：" << endl;
	m_EmpArray[index]->showInfo();
	system("pause");
	system("cls");
	Save();
}
void WorkerManager::find_Emp() {
	int id;
	cout << "请输入Id" << endl;
	cin >> id;
	int index = is_Exist(id);
	if (index == -1)
	{
		cout << "没有查到数据 " << endl;
		return;
	}
	m_EmpArray[index]->showInfo();
}
void WorkerManager::clean_Emp() {
	ofstream ofs(FILENAME, ios::trunc);//如果存在删除文件并重新创建
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
	cout << "清除ok" << endl;
}
void WorkerManager::sort_Emp() {

	if (this->m_EmpNum <= 0)
	{
		cout << "么有数据 排啥 ?" << endl;
		return;
	}
	cout << "请选择 升序还是降序" << endl;
	int type;
	cout << "1:升序，2：降序" << endl;
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
	// 文件不存在
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
	cout << "************ 0.退出管理系统  **************" << endl;
	cout << "************ 1.增加职工信息  **************" << endl;
	cout << "************ 2.显示职工信息  **************" << endl;
	cout << "************ 3.删除职工信息  **************" << endl;
	cout << "************ 4.修改职工信息  **************" << endl;
	cout << "************ 5.查找职工信息  **************" << endl;
	cout << "************ 6.按照编码排序  **************" << endl;
	cout << "************ 7.清空所有文档  **************" << endl;
	cout << "*******************************************" << endl;
	cout << endl;
}
void WorkerManager::ExitSystem() {

	cout << "欢迎下次使用" << endl;
	system("pause");
	exit(0); // 退出程序
}
void WorkerManager::Add_Emp() {
	cout << "请输入增加职工数量" << endl;
	int addNum = 0;
	cin >> addNum;
	if (addNum > 0)
	{
		//计算新空间大小
		int newSize = this->m_EmpNum + addNum;

		// 开辟新空间
		Worker** newSpace = new Worker * [newSize];

		if (this->m_EmpArray != NULL)
		{
			for (int i = 0; i < this->m_EmpNum; i++)
			{
				// 都挪到新数组里面去
				newSpace[i] = this->m_EmpArray[i];
			}
		}
		// 添加新数据
		for (int i = 0; i < addNum; i++)
		{
			int id;
			string name;
			int dSelect;

			cout << "请输入第" << i + 1 << " 个员工的编号：" << endl;
			cin >> id;
			cout << "请输入第" << i + 1 << " 个员工的姓名：" << endl;
			cin >> name;
			cout << "请选择该职工的岗位：" << endl;
			cout << "1 普通员工" << endl;
			cout << "2 经理" << endl;
			cout << "3 老板" << endl;
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

		// 释放原有的空间
		delete[] this->m_EmpArray;
		this->m_EmpArray = newSpace;
		this->m_EmpNum = newSize;
		cout << "成功添加" << addNum << " 名新员工" << endl;
		m_FileIsEmpty = false;
		this->Save();
	}
	else {
		cout << "输入有误" << endl;
	}
	system("pause");
	system("cls");
}

void WorkerManager::Save() {
	ofstream ofs;
	ofs.open(FILENAME, ios::out);//用输出的方式打开 --写文件

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