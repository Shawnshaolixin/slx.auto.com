#include <iostream>
using namespace std;
#include "workerManager.h"
#include "worker.h"
#include "employee.h"
#include "manager.h"
#include "boss.h"
int main()
{

	Worker* worker = NULL;
	worker = new Boss(1, "����", 1);
	worker->showInfo();
	WorkerManager wm;

	int choice = 0;
	while (true)
	{

		wm.Show_Menu();
		cout << "����������ѡ��" << endl;
		cin >> choice;
		switch (choice)
		{
		case 0://�˳�ϵͳ
			wm.ExitSystem();
			break;
		case 1://���ְ��
			wm.Add_Emp();
			break;
		case 2://��ʾְ��
			wm.showWorkerList();
			break;
		case 3://ɾ��ְ��
			wm.delete_Emp();
			break;
		case 4://�޸�ְ��
			wm.edit_Emp();
			break;
		case 5://����ְ��
			wm.find_Emp();
			break;
		case 6://����ְ��
			wm.sort_Emp();
			break;
		case 7://���ְ��
			break;
		default:
			system("cls");
			break;
		}
	}

	system("pause");
	return 0;
}