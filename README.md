## 介绍

C# 中使用【阿里云机器翻译】服务，具体介绍：https://blog.zerow.cn/develop/tool/9dd0730a.html#%E9%98%BF%E9%87%8C%E4%BA%91%E6%9C%BA%E5%99%A8%E7%BF%BB%E8%AF%91%E6%9C%8D%E5%8A%A1

## 业务流程

1. 创建翻译任务（CreateDocTranslateTask）
2. 两种方式获取返回结果（可以二选一）
   1. 创建翻译任务时传递回调地址参数（CallbackUrl）
   2. 直接发送请求（GetDocTranslateTask）

## 功能

提交多语言文件给【阿里云机器翻译】服务，返回翻译后的文件提供下载。