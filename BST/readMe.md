﻿##二叉排序树（Binary Sort Tree）

### 定义
  又称二叉查找树（Binary Search Tree），亦称二叉搜索树。  

二叉排序树或者是一棵空树，或者是具有下列性质的二叉树：  
1. 若左子树不空，则左子树上所有结点的值均小于它的根结点的值；  
2. 若右子树不空，则右子树上所有结点的值均大于它的根结点的值；  
3. 左、右子树也分别为二叉排序树；  
4. 没有键值相等的节点。  

### 查找
步骤：
若根结点的关键字值等于查找的关键字，成功。  
否则，若小于根结点的关键字值，递归查左子树。  
若大于根结点的关键字值，递归查右子树。  
若子树为空，查找不成功。  
平均情况分析（在成功查找两种的情况下）：
在一般情况下，设 P（n，i）为它的左子树的结点个数为 i 时的平均查找长度。如图的结点个数为 n = 6 且 i = 3; 则 P（n,i）= P（6, 3） = [ 1+ ( P(3) + 1) * 3 + ( P(2) + 1) * 2 ] / 6= [ 1+ ( 5/3 + 1) * 3 + ( 3/2 + 1) * 2 ] / 6
注意：这里 P(3)、P(2) 是具有 3 个结点、2 个结点的二叉分类树的平均查找长度。 在一般情况，P（i）为具有 i 个结点二叉分类树的平均查找长度。
P(3) = （1+2+2）/ 3 = 5/3
P(2) = （1+2）/ 2 = 3/2∴ P（n,i）= [ 1+ ( P(i) + 1) * i + ( P(n-i-1) + 1) * (n-i-1) ] / n
∴ P（n）=  P（n,i）/ n <= 2(1+I/n)lnn
因为 2(1+I/n)lnn≈1.38logn 故P(n)=O(logn)

### 插入
与次优二叉树相对，二叉排序树是一种动态树表。其特点是：树的结构通常不是一次生成的，而是在查找过程中，当树中不存在关键字等于给定值的节点时再进行插入。新插入的结点一定是一个新添加的叶子节点，并且是查找不成功时查找路径上访问的最后一个结点的左孩子或右孩子结点。
插入算法编辑
首先执行查找算法，找出被插结点的父亲结点。
判断被插结点是其父亲结点的左、右儿子。将被插结点作为叶子结点插入。
若二叉树为空。则首先单独生成根结点。
注意：新插入的结点总是叶子结点。
