#pragma once
#include<iostream>
using namespace std;

template<class T>
class MyArray {

public:
	MyArray(int capcatiy) {
		//cout << "MyArray���캯��ִ����" << endl;
		this->m_Capacity = capcatiy;
		this->m_Size = 0;
		this->pAddress = new T[this->m_Capacity];
	}
	//β�巨
	void Push_Back(const T& val) {
		//�ж������Ƿ���ڴ�С
		if (this->m_Capacity == this->m_Size)
		{
			return;
		}
		this->pAddress[this->m_Size] = val;
		this->m_Size++;
	}
	void Pop_Back() {
		if (this->m_Size == 0)
		{
			return;
		}
		this->m_Size--;
	}
	int getCap() {
		return this->m_Capacity;
	}
	int getSize() {
		return this->m_Size;
	}
	T& operator[](int index) {

		return this->pAddress[index];
	}
	~MyArray() {
		//cout << "MyArray��������ִ����" << endl;

		if (this->pAddress != NULL)
		{
			delete[] this->pAddress;
			this->pAddress = NULL;

		}
	}
	// ��������
	MyArray(const MyArray& arr) {
		//cout << "MyArray�������캯��ִ����" << endl;

		this->m_Capacity = arr.m_Capacity;
		this->m_Size = arr.m_Size;
		//this->pAddress = arr.pAddress;
		this->pAddress = new T[arr.m_Capacity];
		for (int i = 0; i < this->m_Size; i++)
		{
			this->pAddress[i] = arr.pAddress[i];
		}
	}

	MyArray& operator=(const MyArray& arr) {
		// ���ж�ԭ�������Ƿ�������

		this->pAddress != NULL;
		delete[] this->pAddress;
		this->pAddress = NULL;
		this->m_Capacity = 0;
		this->m_Size = 0;


		this->m_Capacity = arr.m_Capacity;
		this->m_Size = arr.m_Size;
		this->pAddress = new T[arr.m_Capacity];
		for (int i = 0; i < this->m_Size; i++)
		{
			this->pAddress[i] = arr.pAddress[i];
		}
		return *this;
	}
private:
	T* pAddress; //ָ��ָ�������ʵ���ٵĵ�ַ
	int m_Capacity;
	int m_Size;


};
