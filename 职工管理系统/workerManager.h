#pragma once //��ֹͷ�ļ��ظ�����
#include<iostream>
using namespace std;
#include "worker.h"
#include <fstream>
#define FILENAME "empFIle.txt"
class WorkerManager {
public:

	//���캯��
	WorkerManager();

	int m_EmpNum;

	/// <summary>
	/// ְ������ָ��
	/// </summary>
	Worker** m_EmpArray;

	//���ְ��
	void Add_Emp();
	void Save();

	bool m_FileIsEmpty;
	int get_EmpNum();
	void showWorkerList();
	void delete_Emp();
	void init_Emp();
	int is_Exist(int id);
	void edit_Emp();
	void find_Emp();
	void sort_Emp();
	void clean_Emp();
	// չʾ�˵�
	void Show_Menu();
	void ExitSystem();
	// �������� ��������������ʵ��
	~WorkerManager();

};

