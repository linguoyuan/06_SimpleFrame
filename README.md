# 06_SimpleFrame
Unity小项目轻型组件式框架

#### 1、存档模块 DataMgr
实现两种方式保存存档
1、PlayerPrefs方式，这种是针对很简单的数据存储要求的
2、Json序列化方式，针对相对有一定量的存档数据要求的，目前设计了三个类，游戏整体状态，当前游戏状态，主角状态，但是没有具体实现，可以具体需求来设计
同时支持一些本地用户文件的存档

#### 2、游戏初始配置
在游戏一开始的时候，需要读取初始的配置文件数据，这种数据只读在运行过程中不更改。
因为这里针对的是小项目，就意味着数据量并不会很大。
因此，可以采用在场景中直接赋值的办法，但是相对比较混乱，修改不方便，也可以一次性读取存出来放到到自己设计的程序运行时的数据结构。这里采用第二个办法。
这里采用JsonObject这里第三方类进行json文件的解析，非常灵活方便，核心方法GetField。

#### 3、协程管理模块
1、可控制协程开始，暂停，继续，停止，相比原来的协程有所扩展。
2、使得没有挂载mono behaviour也能使用协程。

#### 4、加载模块
加载游戏物体，预制件，图片，材质等资源，也可以加载配置文件
1、Resources方式，已实现
2、AB方式，没实现
3、Addressable方式，已实现，目前这个框架用的方案

#### 5、消息事件模块
1、只执行一次的协程
2、可能需要执行多次的协程，可以开辟缓存
3、流程状态：开始，暂停，继续，结束

#### 6、对象池
1、GameObject对象池
2、普通对象池

#### 7、工具类模块
1、两种单例实现方式，带monobehavior的和不带monobehavior的
2、查找物体工具
3、截图及图片数据转化工具
