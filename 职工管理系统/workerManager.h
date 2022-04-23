#pragma once //防止头文件重复包含
#include<iostream>
using namespace std;
#include "worker.h"
#include <fstream>
#define FILENAME "empFIle.txt"
class WorkerManager {
public:

	//构造函数
	WorkerManager();

	int m_EmpNum;

	/// <summary>
	/// 职工数组指针
	/// </summary>
	Worker** m_EmpArray;

	//添加职工
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
	// 展示菜单
	void Show_Menu();
	void ExitSystem();
	// 析构函数 仅做声明，不做实现
	~WorkerManager();

};

