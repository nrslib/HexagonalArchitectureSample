# プロジェクトの説明
ヘキサゴナルアーキテクチャのサンプルです。  
C#で記述されています。  

詳しい解説はホームページに記載します。  
[https://srnlib.com/hexagonal-architecture/](https://srnlib.com/hexagonal-architecture/ "https://srnlib.com/hexagonal-architecture/")

-----

# 構造
ポートアダプターの形を取っています。  

## Presentation
ASP.net MVC(.NET Framework)で構成されています。  
プライマリアダプタの実装です。  

## Application
DDDでいうアプリケーション層です。  
プライマリポートにあたります。  

## Domain
ドメイン層です。  
ヘキサゴナルアーキテクチャ上のApplicationです。  
またRepositoryはセカンダリポートを表しています。  
ビジネスロジックを表現しており、そのほかの層の何にも依存しないように実装します。  

## InMemoryDataStore
インフラストラクチャ層です。  
セカンダリアダプタの実装です。  
集約(Aggregate root)を構築する役目を担います。  
DAOやEntityFrameworkを活用したインフラストラクチャ層を構築するときは別プロジェクトにすることが予想されます。  

## MyLibrary
特にどれにも属さない共通クラスライブラリです。  

-----

# Description
This is a sample of hexagonal architecture.　　

-----
# Structure

## Presentation
Using ASP.net MVC (.NET Framework).
Primary adapter.

## Application
Application layer.  
Primary port.

## Domain
Domain layer.  
Application in hexagonal architecture.  
Repository is secondary port.
Business logic descrived here.  

## InMemoryDataStore
Infrastructure layer.  
secondary adapter.
Implementation for the data store exists.  
If you need DAO -- Oracle, Mysql , etc --, You should make new project.  

## MyLibrary
Common library  
This is a library not belonging to any one.

---