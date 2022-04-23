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
	worker = new Boss(1, "张三", 1);
	worker->showInfo();
	WorkerManager wm;

	int choice = 0;
	while (true)
	{

		wm.Show_Menu();
		cout << "请输入您的选择" << endl;
		cin >> choice;
		switch (choice)
		{
		case 0://退出系统
			wm.ExitSystem();
			break;
		case 1://添加职工
			wm.Add_Emp();
			break;
		case 2://显示职工
			wm.showWorkerList();
			break;
		case 3://删除职工
			wm.delete_Emp();
			break;
		case 4://修改职工
			wm.edit_Emp();
			break;
		case 5://查找职工
			wm.find_Emp();
			break;
		case 6://排序职工
			wm.sort_Emp();
			break;
		case 7://清空职工
			break;
		default:
			system("cls");
			break;
		}
	}

	system("pause");
	return 0;
}