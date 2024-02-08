# event-pad
# 1. Концепт
Данный сервис предоставит возможность организовывать, проводить и посещать мероприятия. Для примера возьмем тренировку по волейболу в ВГУ. Приложение позволит создать мероприятие “Тренировка по волейболу”, которое будет содержать всю информацию, и информацию о людях, которые планируют её посетить и оплатили тренировку.
# 2. Цели и задачи
1.	Организация мероприятий
2.	Посещение мероприятий
  - 2.1. Организация мероприятий
Любой пользователь сможет организовывать свои мероприятия, такой пользователь будет называться “Администратор мероприятия”. Мероприятие может быть доступно всем зарегистрированным пользователям или же оно может быть приватное, в этом случае доступ к нему задается по ссылке. 
Администратор мероприятия может:
    -	Создать мероприятие
    -	Удалить мероприятие
    - Редактировать информацию
    -	Получить список записавшихся пользователей на мероприятие
  - 2.2. Посещение мероприятий
Пользователи видеть доступные ему мероприятия, записываться на них, оплачивать при необходимости.
 
# 3. Предметная область
  - 3.1. Мероприятие
Мероприятие – это организованное событие, которое имеет:
    -	Администратора мероприятия
    -	Название
    -	Описание
    -	Дату
    -	Время
    -	Место
    -	Фото
    -	Стоимость
    -	Дата окончания приема средств
  - 3.2. Пользователь
Пользователь – это любой человек зарегистрированный в приложении. Пользователь имеет:
    -	Логин(телефон)
    -	Пароль
    -	ФИО
    -	Подписки на мероприятия
    -	Баланс
    -	Созданные им мероприятия

    ![Image](https://github.com/MYP4/event-pad/blob/main/DataBase.jpg)
    
# 4. Функциональное описание
  - 4.1. Администрирование мероприятия
Создание мероприятия выполняется любым пользователем. После создания мероприятия его автор становится “Администратором мероприятия”. 
Для работы необходимо чтобы пользователь был зарегистрирован и авторизован.
    - 4.1.1. Создание мероприятия
      - Нажать “Мои мероприятия”;
      -	Нажать “Создать мероприятие”;
      - Заполнить необходимую информацию о мероприятии;
      - Общую информацию;
      - Указать видимость мероприятия;
      - Указать стоимость;
      -	Нажать “Опубликовать мероприятие”.
    -	4.1.2. Просмотр мероприятия
      - Нажать “Мои мероприятия”;
        - Выбрать необходимое мероприятие;
        - Просмотр необходимой информации;
          - Просмотр списка посетителей;
          - Просмотр оплаты пользователей;
    - 4.1.3. Редактирование мероприятия
      - Нажать “Мои мероприятия”;
      - Выбрать необходимое мероприятие;
      - Редактировать информацию;
      - Сохранить редактированные данные;
    - 4.1.4. Удаление мероприятия
      - Нажать “Мои мероприятия”;
      - Выбрать необходимое мероприятие;
      - Нажать “Удалить мероприятие”;
        - Если мероприятие содержит посетителей, оплативших его, то оно архивируется.
        - Если мероприятие не содержит посетителей, оплативших его, то оно удаляется.

    - 4.2. Подписка на мероприятие
Для работы необходимо чтобы пользователь был зарегистрирован и авторизован.
      - 4.2.1. Подписка на мероприятие
        - Выбрать необходимое мероприятие;
        - Нажать кнопку “Подписаться на мероприятие”;
        - Оплатить посещение мероприятия до указанной даты.
      - 4.2.2. Отписка от мероприятия
        - Выбрать необходимое мероприятие;
        - Нажать кнопку “Отписаться от мероприятия”;
        - Подтвердить отписку (если мероприятие оплачено, необходимо связаться с администратором мероприятия).
      - 4.2.3. Оплата мероприятия
Оплата будет происходить через сервис Robocassa. Он позволяет не работать с банковскими транзакциями на прямую, а предоставляет необходимые функции для этого.
