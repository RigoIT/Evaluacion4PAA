-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 30-07-2022 a las 08:00:33
-- Versión del servidor: 10.4.24-MariaDB
-- Versión de PHP: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `sanremo_db`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cancion`
--

CREATE TABLE `cancion` (
  `id_cancion` int(11) NOT NULL,
  `id_cantautor` int(11) NOT NULL,
  `nombre_cancion` varchar(250) NOT NULL,
  `posicion` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `cancion`
--

INSERT INTO `cancion` (`id_cancion`, `id_cantautor`, `nombre_cancion`, `posicion`) VALUES
(1, 1, 'Solo Noi', 1),
(2, 1, 'Volo AZ504', 3),
(3, 1, 'Gran Premio', 6),
(4, 1, 'L\'italiano', 5),
(5, 1, 'Serenata', 2),
(6, 1, 'Azzurra Malinconia', 4),
(7, 1, 'Figli', 2),
(8, 1, 'Emozioni', 2),
(9, 1, 'Le Mamme', 2),
(10, 1, 'Gli Amori', 2),
(11, 2, 'Per Elisa', 1),
(12, 2, 'Il Mio Cuore Se Ne Va', 4),
(13, 5, 'Devo Dirti Di No', 5),
(14, 5, 'La Siepe', 4),
(15, 5, 'Storia D\'oggi', 5),
(16, 5, 'Felicita', 2),
(17, 5, 'Ci Sara', 1),
(18, 5, 'Oggi Sposi', 5),
(19, 7, 'Adesso Tu', 1),
(20, 7, 'Terra Promessa', 3),
(21, 7, 'Una Storia Importante', 5),
(22, 3, 'Storie Di Tutti Giorni', 1),
(23, 3, 'Tanta Voglia Di Lei', 5),
(24, 4, 'Sara Quel Che Sara', 1),
(25, 6, 'Se M\'innamoro', 1),
(26, 6, 'La Prima Cosa Bella', 2),
(27, 6, 'Che Sara', 2),
(28, 6, 'Un Diadema Di Ciliegie', 11),
(29, 6, 'Canzone D\'amore', 7),
(30, 6, 'Così Lontani', 20),
(31, 1, 'Voglio Andare A Vivere In Campagna', 15);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cantautor`
--

CREATE TABLE `cantautor` (
  `id_cantautor` int(11) NOT NULL,
  `nombre_cantautor` varchar(250) NOT NULL,
  `primera_presentacion` date NOT NULL,
  `canciones_publicadas` int(11) NOT NULL,
  `vigencia` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `cantautor`
--

INSERT INTO `cantautor` (`id_cantautor`, `nombre_cantautor`, `primera_presentacion`, `canciones_publicadas`, `vigencia`) VALUES
(1, 'Toto Cutugno', '1976-01-31', 520, 1),
(2, 'Alice', '1981-01-31', 200, 1),
(3, 'Riccardo Fogli', '1982-01-31', 350, 1),
(4, 'Tiziana Rivale', '1983-01-31', 150, 1),
(5, 'Al Bano & Romina Power', '1984-01-31', 300, 1),
(6, 'Ricchi e Poveri', '1985-01-31', 300, 1),
(7, 'Eros Ramazzotti', '1986-01-31', 400, 1);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `cancion`
--
ALTER TABLE `cancion`
  ADD PRIMARY KEY (`id_cancion`),
  ADD KEY `id_cantautor` (`id_cantautor`),
  ADD KEY `id_cantautor_2` (`id_cantautor`);

--
-- Indices de la tabla `cantautor`
--
ALTER TABLE `cantautor`
  ADD PRIMARY KEY (`id_cantautor`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `cancion`
--
ALTER TABLE `cancion`
  MODIFY `id_cancion` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=32;

--
-- AUTO_INCREMENT de la tabla `cantautor`
--
ALTER TABLE `cantautor`
  MODIFY `id_cantautor` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `cancion`
--
ALTER TABLE `cancion`
  ADD CONSTRAINT `cancion_ibfk_1` FOREIGN KEY (`id_cantautor`) REFERENCES `cantautor` (`id_cantautor`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
