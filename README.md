# Jonty.Blog🎯

## 项目介绍📚

-------

个人博客项目，底层基于免费开源跨平台的[.NET Core 3.1](https://docs.microsoft.com/zh-cn/dotnet/core/)开发，使用 [ABP vNext](https://abp.io/)搭建项目框架，支持主流数据库(MSSQL,MySQL,SQLite，MongoDB暂时还不会啊😅)，遵循RESTful接口规范。觉得不错请点个小⭐⭐~~~😁

## 技术栈📑

---

- [x] 使用abp cli搭建项目
- [x] Autofac依赖注入
- [x] 自定义Swagger-API文档
- [x] Code First和自定义仓储
- [x] JWT-GitHub授权
- [x] 异常处理-log4Net
- [x] Redis数据缓存
- [x] Hangfire定时任务
- [x] AutoMapper对象映射
- [x] 百度AI-语音合成
- [x] HtmlAgilityPack 爬虫
- [x] MailKit 邮件提醒
- [x] 腾讯MTA+验证码
- [ ] 接口测试
- [ ] 前台页面

## 项目目录📒

---

```
Blog ---------- root
 ├── .gitattributes ---------- git attributes
 ├── .gitignore ---------- git ignore
 ├── common.props ---------- common.props
 ├── LICENSE ---------- LICENSE
 ├── Jonty.Blog.sln ---------- Solution
 ├── README.md ---------- README.md
 ├── src
 │   ├── Jonty.Blog.Application ---------- Application
 │   ├── Jonty.Blog.Application.Caching ---------- Application.Caching
 │   ├── Jonty.Blog.Application.Contracts ---------- Application.Contracts
 │   ├── Jonty.Blog.BackgroundJobs ---------- BackgroundJobs
 │   ├── Jonty.Blog.Domain ---------- Domain
 │   ├── Jonty.Blog.Domain.Shared ---------- Domain.Shared
 │   ├── Jonty.Blog.EntityFrameworkCore ---------- EntityFrameworkCore
 │   ├── Jonty.Blog.EntityFrameworkCore.DbMigrations ---------- EntityFrameworkCore.DbMigrations
 │   ├── Jonty.Blog.HttpApi ---------- HttpApi
 │   ├── Jonty.Blog.HttpApi.Hosting ---------- HttpApi.Hosting
 │   ├── Jonty.Blog.Swagger ---------- Swagger
 │   └── Jonty.Blog.ToolKits ---------- ToolKits
 └── static ---------- static
```

:record_button:   Application—应用服务层：编写服务的接口及对应实现

:record_button:   Application.Caching—缓存服务层：处理缓存

:record_button:   Application.Contracts—数据传输层：传输对象(DTO)

:record_button:   BackgroundJobs—定时任务层：Hangfire定时任务

:record_button:   Domain—实体模型层：实体领域模型

:record_button:   Domain.Shared—公共实体层：枚举、公共常量

:record_button:   EntityFrameworkCore—仓储服务层：集成EF Core,自定义仓储

:record_button:   EntityFrameworkCore.DbMigrations—数据迁移层：数据迁移，code-first建库建表

:record_button:   HttpApi—应用接口层：编写Controller，API

:record_button:   HttpApi.Hosting—Web层：暴露API

:record_button:   Swagger—接口文档层：Swagger文档(可直接写在`HttpApi.Hosting`)

:record_button:   ToolKits—扩展工具层：扩展方法、工具类

## 预览📃

---

### 页面展示🔎

俺还没做~~~ 没时间，无从下手，有合适的可以推荐一下📩<501211312@qq.com>

#### 首页 

![](static/7.png)

#### 文章列表

![](static/8.png)



> 分类和标签页大致如此😄

### API展示🔎

#### 博客前台接口🖊

![](static/1.png)

#### JWT身份认证🖍

![](static/2.png)

#### 公共接口🖋

![](static/3.png)

![](static/5.png)

![](static/6.png)

#### 身份认证接口🖌

![](static/4.png)



> 此项目`v1.0.0`版本学习于[阿星 Plus](https://github.com/Meowv/Blog),作为个人.NET Core入门学习,感谢星哥指导🤞。

博客园地址：[阿星Plus](https://www.cnblogs.com/meowv/p/12896177.html)

GitHub地址：[阿星Plus](https://github.com/Meowv/Blog)

