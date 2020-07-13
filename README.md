# Jonty.Blog🎯

## 项目介绍📚

-------

🎯Jonty.Blog个人博客项目，底层基于免费开源跨平台的[.NET Core 3.1](https://docs.microsoft.com/zh-cn/dotnet/core/)开发，使用 [ABP vNext](https://abp.io/)搭建项目框架，支持主流数据库(MSSQL,MySQL,SQLite，MongoDB暂时还不会啊😅)，遵循RESTful接口规范,前端使用Blazor开发。觉得不错请点个小⭐⭐~~~😁

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
- [x] 前台页面
- [ ] 接口测试

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
 │   ├── Jonty.Blog.BlazorApp ---------- BlazorApp
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

:record_button:   BlazorApp:前端页面

:record_button:   Swagger—接口文档层：Swagger文档(可直接写在`HttpApi.Hosting`)

:record_button:   ToolKits—扩展工具层：扩展方法、工具类

---

## 使用说明🚗

- 克隆代码，使用打开工具打开

- 在`HttpApi.Hosting`中修改`appsettings.json`

  > ConnectionStrings: 配置数据库连接字符串
  >
  > JWT：配置`Json Token`
  >
  > GitHub:配置`OAuth App` ,Github开发人员设置
  >
  > Caching:配置`Redis`缓存
  >
  > Hangfire:配置定时任务管理用户密码
  >
  > BaiduAI:配置百度语音合成API

- `EntityFrameworkCore.DbMigrations`设为启动项目，打开程序包管理器控制台,启动迁移。

```cmd
add-migration ''
update-database
```

- 更改`BlazorApp`—>`Program`中地址为本地：https://localhost:44335/

---

## 预览📃

---

### 页面展示🔎

#### 首页 

https://www.jonty.top

![](https://gitee.com/my_netinlove/Picturebed/raw/master/images/index.png)

