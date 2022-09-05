-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1
-- Время создания: Сен 05 2022 г., 10:39
-- Версия сервера: 10.4.24-MariaDB
-- Версия PHP: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `internshipdb`
--

-- --------------------------------------------------------

--
-- Структура таблицы `internship`
--

CREATE TABLE `internship` (
  `ID` int(11) NOT NULL,
  `Student_ID` int(11) NOT NULL,
  `company_id` int(11) NOT NULL,
  `start_date` date NOT NULL,
  `end_date` date DEFAULT NULL,
  `description` varchar(300) NOT NULL,
  `requirement` varchar(300) NOT NULL,
  `active` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `internship`
--

INSERT INTO `internship` (`ID`, `Student_ID`, `company_id`, `start_date`, `end_date`, `description`, `requirement`, `active`) VALUES
(1, 1, 2, '2022-09-01', '2022-09-30', 'some desc', 'some req', 1);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `internship`
--
ALTER TABLE `internship`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `Student_ID` (`Student_ID`),
  ADD KEY `internship_ibfk_1` (`company_id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `internship`
--
ALTER TABLE `internship`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `internship`
--
ALTER TABLE `internship`
  ADD CONSTRAINT `internship_ibfk_1` FOREIGN KEY (`company_id`) REFERENCES `company` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `internship_ibfk_2` FOREIGN KEY (`Student_ID`) REFERENCES `university_students` (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
