#pragma once
#include<iostream>
using namespace std;

/// <summary>
/// ������
/// </summary>
class Worker {
public:
	// ��ʾ������Ϣ
	virtual void showInfo() = 0;//���麯��
	// ��ȡ��λ��Ϣ
	virtual string getDeptName() = 0;

	int m_Id; //ְ�����
	string m_Name;//ְ������
	int m_DeptId;//ְ�����ڲ������Ʊ��
};
