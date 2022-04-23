#pragma once
#include "worker.h"
using namespace std;

class Manager :public Worker {
public:
	Manager(int id, string name, int dId);
	// 显示个人信息
	virtual void showInfo();
	// 获取岗位信息
	virtual string getDeptName();

};