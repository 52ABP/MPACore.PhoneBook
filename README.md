

## 必备条件
#### nuget 配置
首先设置开发环境，打开nuget程序包管理器，添加一个nuget源。
```
https://dotnet.myget.org/F/aspnetcore-dev/api/v3/index.json
```
如图所示：
![Nuget Option](docs/images/readme/nugetOption.png)
然后生成解决方案。

#### 数据库的生成
选择EntityFrameworkCore层，作为默认
![Generator Data Base](docs/images/readme/GeneratorDataBase.png)
执行
```
update-database
```


