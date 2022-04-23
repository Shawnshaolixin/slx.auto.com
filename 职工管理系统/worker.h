#pragma once
#include<iostream>
using namespace std;

/// <summary>
/// 抽象类
/// </summary>
class Worker {
public:
	// 显示个人信息
	virtual void showInfo() = 0;//纯虚函数
	// 获取岗位信息
	virtual string getDeptName() = 0;

	int m_Id; //职工编号
	string m_Name;//职工姓名
	int m_DeptId;//职工所在部门名称编号
};
