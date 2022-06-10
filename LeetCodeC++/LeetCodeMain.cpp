#include <iostream>
using namespace std;
#include <vector>


struct TreeNode {
	int val;
	TreeNode* left;
	TreeNode* right;
	TreeNode() : val(0), left(nullptr), right(nullptr) {}
	TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
	TreeNode(int x, TreeNode* left, TreeNode* right) : val(x), left(left), right(right) {}
};

class Solution {
public:
	TreeNode* deleteNode(TreeNode* root, int key)
	{
		if (root == nullptr) return nullptr;
		if (key > root->val) // 目标节点大于当前节点值，去右子树里面删
		{
			root->right = deleteNode(root->right, key);
		}
		else if (key < root->val)// 目标节点小于当前值，去左子树里面删
		{
			root->left = deleteNode(root->left, key);
		}
		else // 找到值了
		{
			if (!root->left)// 如果没有左子树
			{
				return root->right; // 右子树顶替他的位置
			}
			if (!root->right) // 没有右子树
			{
				return root->left; // 左子树顶替他的位置
			}
			TreeNode* node = root->right;
			// 左右节点都有 
			while (node->left)
			{
				node = node->left;
			}
			node->left = root->left; // 左子树转移到 右子树的最左节点的左子树上，然后右子树顶替他的位置
			root = root->right;
		}
		return root;
	}
	/// <summary>
	/// 偶数往前方
	/// </summary>
	/// <param name="nums"></param>
	/// <returns></returns>
	vector<int> sortArrayByParity(vector<int>& nums)
	{
		int index = 0;
		int i = 0;
		while (i < nums.size() - index)
		{
			if (nums[i] % 2 != 0)// 如果当前这个数 是奇数，就和最后一个做交换
			{
				int temp = nums[nums.size() - 1 - index];
				nums[nums.size() - 1 - index] = nums[i];
				nums[i] = temp;
				index++;
				continue;
			}
			i++;
		}
		return nums;
	}
	/// <summary>
	/// 三数之和
	/// </summary>
	/// <param name="nums"></param>
	/// <returns></returns>
	vector<vector<int>> threeSum(vector<int>& nums) {

	}
	/// <summary>
	/// 返回的是下一个的索引
	/// </summary>
	/// <param name="v"></param>
	/// <param name="k">步长</param>
	/// <returns></returns>
	int findNextStartIndex(vector<int>& v, int k) {

	}
	/// <summary>
	/// 1823. 找出游戏的获胜者
	/// </summary>
	/// <param name="n"></param>
	/// <param name="k"></param>
	/// <returns></returns>

	int findTheWinner(int n, int k)
	{
		// 约瑟夫环
		vector<int> v;
		int count = n;
		int startIndex = 0;
		for (int i = 1; i <= n; i++)
		{
			v.push_back(i);
		}

		findNextStartIndex(v, k);


		return 0;
	}
	/// <summary>
	/// 最长回文字串
	/// </summary>
	/// <param name="s"></param>
	/// <returns></returns>

	string longestPalindrome(string s) {
		/*	输入：s = "babad"
			输出："bab"
			解释："aba" 同样是符合题意的答案。*/
		int low = 0;
		int fast = s.length() - 1;

		int startIndex = 0;
		int endIndex = fast;


		while (low < fast)
		{
			if (s[startIndex] == s[endIndex])
			{
				startIndex++;
				endIndex--;
				if (endIndex > startIndex)
				{

				}
			}
		}

	}
	/// <summary>
	/// 647.回文字串
	/// </summary>
	/// <param name="s"></param>
	/// <returns></returns>
	int countSubstrings(string s) {

	}

	string longestCommonPrefix(vector<string>& strs) {
		int len = 0;
		while (len < strs[0].size())
		{
			for (int i = 0; i < strs.size() - 1; i++)
			{
				if (strs[i].size() <= len || strs[i + 1].size() <= len)
				{
					// Console.WriteLine("长度不够跳出了");
					return strs[0].substr(0, len);
				}
				char qian = strs[i][len]; // 前一个数的 第j为字母
				char hou = strs[i + 1][len]; // 后一位数的 第j 为字母
				if (qian != hou)
				{
					// 有一个不等的就可以跳出来了
					return strs[0].substr(0, len);
				}
			}
			len++;
		}
		return strs[0].substr(0, len);
	}

	bool isExist(vector<int>& v, int value) {
		for (vector<int>::iterator it = v.begin(); it != v.end(); it++)
		{
			if (*it == value)
			{
				return true;
			}
		}
		return false;
	}
	vector<int> findDuplicates(vector<int>& nums) {

		vector<int> result;
		int lowIndex = 0;
		int len = nums.size();
		while (lowIndex < len)
		{
			while (nums[lowIndex] != lowIndex + 1)
			{
				int temp = nums[nums[lowIndex] - 1];
				if (temp == nums[lowIndex])
				{
					if (!isExist(result, temp))
					{
						result.push_back(temp);
					}

					//  lowIndex++;
					break;
				}
				else
				{
					nums[nums[lowIndex] - 1] = nums[lowIndex];
					nums[lowIndex] = temp;

				}
			}
			lowIndex++;
		}
		return result;
	}


	vector<int> diStringMatch(string s) {
		vector<int> arr;
		for (size_t i = 0; i <= s.size(); i++)
		{
			arr.push_back(i);
		}
		vector<int> result;
		int lowIndex = 0;
		int fastIndex = arr.size() - 1;
		while (lowIndex < fastIndex)
		{
			for (size_t i = 0; i < s.size(); i++)
			{
				if (s[i] == 'D')
				{
					result.push_back(arr[fastIndex]);
					fastIndex--;
				}
				else {
					result.push_back(arr[lowIndex]);
					lowIndex++;
				}

			}
		}
		result.push_back(arr[lowIndex]);
		return result;
	}

	void traversal(TreeNode* root, vector<int>& v) {

		if (root == NULL)
		{
			return;
		}
		v.push_back(root->val);
		traversal(root->left, v);
		traversal(root->right, v);

	}

	vector<int> preorderTraversal(TreeNode* root) {
		vector<int> v;
		traversal(root, v);
		return v;
	}

};
class RecentCounter {
public:
	RecentCounter() {

	}
	vector<int> list;
	int ping(int t) {
		int count = 0;

		list.push_back(t);
		int lastIndex = list.size() - 1;
		int value = list[lastIndex];
		while (t - value <= 3000 && lastIndex >= 0)
		{
			count++;
			if (lastIndex == 0)
			{
				return count;
			}
			lastIndex--;
			value = list[lastIndex];

		}

		return count;
	}
};
int main()
{
	Solution so;


	vector<int> arr;

	arr.push_back(4);
	arr.push_back(3);
	arr.push_back(2);
	arr.push_back(7);
	arr.push_back(8);
	arr.push_back(2);
	arr.push_back(3);
	arr.push_back(1);

	so.findDuplicates(arr);
	so.diStringMatch("DIDI");
	//so.sortArrayByParity(arr);
	//so.findTheWinner(5, 2);
	return 0;
}