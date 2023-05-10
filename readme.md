# Описание проекта

В данном проекте я постарался разделить логику на разные уровни архитектуры: Busines Layer, Database, Presentation Layer.

**Схема базы данных:**

<img src="image\readme\1683747668220.png" alt="drawing" width="300"/>

**Далее небольшое описание о каждом уровне:**

* Database: в нём описаны модели базы данных, транзакции и контекстный класс для подключючения.
* Business layer: находится основной класс Manager для всех возможных операций с пользователями, а так же класс Password для хеширования паролей.
* Presentation: к уровню был подключён Controller c Get и Post методами. Так же для каждой страницы был написан html код
---
<center>
    <img src="image/readme/1683749336876.png" alt="drawing" width="300"/>
</center>