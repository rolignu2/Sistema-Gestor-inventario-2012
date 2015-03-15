-- phpMyAdmin SQL Dump
-- version 3.4.10.1deb1
-- http://www.phpmyadmin.net
--
-- Servidor: localhost
-- Tiempo de generación: 02-10-2012 a las 20:41:22
-- Versión del servidor: 5.5.24
-- Versión de PHP: 5.3.10-1ubuntu3.4

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de datos: `delatorre`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `clientes`
--

CREATE TABLE IF NOT EXISTS `clientes` (
  `idcliente` int(11) NOT NULL AUTO_INCREMENT,
  `fechaInicio` date NOT NULL,
  `nombre` varchar(255) NOT NULL,
  `apellido` varchar(255) NOT NULL,
  `idtelefono` int(11) DEFAULT NULL,
  `idemail` int(11) DEFAULT NULL,
  PRIMARY KEY (`idcliente`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=24 ;

--
-- Volcado de datos para la tabla `clientes`
--

INSERT INTO `clientes` (`idcliente`, `fechaInicio`, `nombre`, `apellido`, `idtelefono`, `idemail`) VALUES
(12, '2012-09-15', 'rolando antonio', 'arriaza', 63838177, 64115797),
(15, '2012-09-16', 'ramon', 'valdez', 9567778, 89862889),
(16, '2012-09-21', 'maria', 'antonieta', 9584862, 16796693),
(19, '2012-09-27', 'mario', 'belloso', 6183295, 6164783),
(20, '2012-09-28', 'damian', 'villacorta', 45267955, 52597489),
(21, '2012-09-28', 'juan ', 'perez', 47523049, 9984270),
(22, '2012-10-02', 'maria', 'magdalena', 72373133, 4444818),
(23, '2012-10-01', 'fernando', 'marroquin', 16214391, 9863749);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `Compras`
--

CREATE TABLE IF NOT EXISTS `Compras` (
  `idcompras` varchar(255) NOT NULL,
  `nombre` varchar(255) NOT NULL,
  `fecha` date NOT NULL,
  `cantidad` int(11) NOT NULL,
  `costo` float NOT NULL,
  PRIMARY KEY (`idcompras`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `Compras`
--

INSERT INTO `Compras` (`idcompras`, `nombre`, `fecha`, `cantidad`, `costo`) VALUES
('CPRS15818039', 'alternadores', '2012-09-20', 200, 10000),
('CPRS37721059', 'condensadores', '2012-10-02', 200, 4500),
('CPRS4371666', 'compresores', '2012-10-02', 70, 8500),
('CPRS4710867', 'filtros', '2012-10-03', 100, 2500),
('CPRS48408697', 'repuestos varios', '2012-10-02', 200, 650),
('CPRS7339436', 'ventiladores', '2012-10-01', 5, 8.5),
('CPRS7373657', 'motores', '2012-07-09', 40, 4000),
('CPRS99914247', 'ventiladores', '2012-10-03', 100, 1500);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `Devolucion`
--

CREATE TABLE IF NOT EXISTS `Devolucion` (
  `id_devolucion` varchar(255) NOT NULL,
  `idfactura` varchar(255) NOT NULL,
  `fecha` date NOT NULL,
  `estado` bit(1) NOT NULL,
  PRIMARY KEY (`id_devolucion`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `email`
--

CREATE TABLE IF NOT EXISTS `email` (
  `idemail` int(11) NOT NULL,
  `email` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `email`
--

INSERT INTO `email` (`idemail`, `email`) VALUES
(64115797, 'rolando@gmail.com'),
(5558126, ''),
(89862889, 'ramon_@gmail.com'),
(16796693, 'maria_@gmail.com'),
(6164783, 'unpurodemarihuana@hotmail.com'),
(52597489, 'damian.villacorta@gmail.com'),
(9984270, ''),
(4444818, 'marialallorona@hotmail.com'),
(9863749, 'fernu@hotmail.com');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `empleados`
--

CREATE TABLE IF NOT EXISTS `empleados` (
  `idempleado` varchar(255) NOT NULL,
  `idusuario` int(11) DEFAULT NULL,
  `Nombre` varchar(255) NOT NULL,
  `Apellido` varchar(255) NOT NULL,
  `Dui` varchar(16) NOT NULL,
  `Salario` decimal(10,0) DEFAULT NULL,
  `idsucursal` varchar(255) NOT NULL,
  `Cargo` varchar(255) NOT NULL,
  `Estado` bit(1) NOT NULL,
  PRIMARY KEY (`idempleado`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `empleados`
--

INSERT INTO `empleados` (`idempleado`, `idusuario`, `Nombre`, `Apellido`, `Dui`, `Salario`, `idsucursal`, `Cargo`, `Estado`) VALUES
('emp100105', 2, 'rolando', 'arriaza', '45553366-5', 4000, 'SU200', 'administrador', b'1'),
('emp2005', 5, 'herberth', 'gonzales', '455666332', 10, 'suc100', 'mendigo', b'1'),
('EMP3261392', 0, 'alsajib', 'dalailama', '455887785555-9', 450, 'Su1002011', 'cajero', b'1'),
('EMP7876172', NULL, 'mario', 'alvarado', '455566696663-9', 350, 'Su1003011', 'cajero', b'1'),
('EMP92202222', 32, 'rolando antonio', 'arrriaza marroquin', '4455663366-5', 1500, 'Su1003011', 'administrador', b'1');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `Factura`
--

CREATE TABLE IF NOT EXISTS `Factura` (
  `idfactura` varchar(255) NOT NULL,
  `nombre` varchar(255) NOT NULL,
  `fecha` date NOT NULL,
  `idproducto` varchar(255) NOT NULL,
  `idcliente` varchar(255) NOT NULL,
  `hora` time NOT NULL,
  PRIMARY KEY (`idfactura`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `Factura`
--

INSERT INTO `Factura` (`idfactura`, `nombre`, `fecha`, `idproducto`, `idcliente`, `hora`) VALUES
('A100', 'REPARACION', '2012-08-01', 'P10', 'A100', '10:30:00');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pnuevos`
--

CREATE TABLE IF NOT EXISTS `pnuevos` (
  `idpnuevos` varchar(255) NOT NULL,
  `nombre` varchar(255) NOT NULL,
  `fecha` date NOT NULL,
  `precio` decimal(10,0) DEFAULT NULL,
  `cantidad` int(255) NOT NULL,
  `descuentos` varchar(255) NOT NULL,
  `garantia` int(1) NOT NULL,
  PRIMARY KEY (`idpnuevos`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `pnuevos`
--

INSERT INTO `pnuevos` (`idpnuevos`, `nombre`, `fecha`, `precio`, `cantidad`, `descuentos`, `garantia`) VALUES
('PN2499520', 'filtros', '2012-10-02', 25, 100, '0', 1),
('PN36718845', 'contenedores', '2012-10-08', 100, 10, '10', 1),
('PN7274678', 'alternador ', '2012-10-02', 45, 100, '10', 1),
('PN73681431', 'ventiladores 12v', '2012-10-02', 15, 25, '5', 1),
('PN9595943', 'compreso 15v', '2012-04-10', 150, 200, '15', 1),
('PN96241130', 'Samsung RS261MDBP Black 26 ', '2012-10-02', 700, 2, '5', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `productos`
--

CREATE TABLE IF NOT EXISTS `productos` (
  `idproductos` varchar(255) NOT NULL,
  `idpusados` varchar(255) NOT NULL,
  `idpnuevos` varchar(255) NOT NULL,
  `existente` int(1) NOT NULL,
  `activo` int(1) NOT NULL,
  `idproveedores` varchar(255) NOT NULL,
  PRIMARY KEY (`idproductos`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `productos`
--

INSERT INTO `productos` (`idproductos`, `idpusados`, `idpnuevos`, `existente`, `activo`, `idproveedores`) VALUES
('PROD2153861', 'NULL', 'PN36718845', 1, 0, 'PROV2538851'),
('PROD22887851', 'PU76946185', 'NULL', 1, 1, 'PROV39152120'),
('PROD43629765', 'NULL', 'PN9595943', 1, 1, 'PROV66839362'),
('PROD449792', 'NULL', 'PN96241130', 1, 1, 'PROV39152120'),
('PROD56896456', 'NULL', 'PN7274678', 1, 1, 'PROV19701426'),
('PROD5774839', 'PU85745410', 'PN2499520', 1, 0, 'PROV36325022'),
('PROD59414882', 'PU42723426', 'NULL', 1, 1, 'PROV66839362'),
('PROD8863954', 'PU2436783', 'PN73681431', 1, 0, 'PROV76655815');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `Proveedores`
--

CREATE TABLE IF NOT EXISTS `Proveedores` (
  `idproveedor` varchar(255) NOT NULL,
  `nombre` varchar(255) NOT NULL,
  `direccion` varchar(255) DEFAULT NULL,
  `telefono` varchar(8) NOT NULL,
  `sitioweb` varchar(255) DEFAULT NULL,
  `idcompras` varchar(255) NOT NULL,
  PRIMARY KEY (`idproveedor`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `Proveedores`
--

INSERT INTO `Proveedores` (`idproveedor`, `nombre`, `direccion`, `telefono`, `sitioweb`, `idcompras`) VALUES
('PROV19701426', 'herberth', 'cd', '22122202', 'telefe.com', 'CPRS15818039'),
('PROV2538851', 'bc-db', '29 ave norte, por la nacional', '22857412', '', 'CPRS4710867'),
('PROV36325022', 'cualitas', '79 ave sur cualitas s.a de c.v', '22745981', 'www.cualitas.com', 'CPRS48408697'),
('PROV39152120', 'rolando', '75 ave norte calle mano de leon', '22620282', 'www.rsoft.com', 'CPRS99914247'),
('PROV53339910', 'sonya', 'avenida park ', '22664455', 'www.sonya.com', 'CPRS7373657'),
('PROV66839362', 'industrias compresor', '75 ave norte calle mano de leon', '22654885', '', 'CPRS4371666'),
('PROV76655815', 'marco tulio', 'restringida', '55255665', 'www.tulito.com', 'CPRS7339436'),
('PROV92203515', 'nwork', '', '22645899', 'www.nwork.ideas.com', 'CPRS37721059');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pusados`
--

CREATE TABLE IF NOT EXISTS `pusados` (
  `idpusado` varchar(255) NOT NULL,
  `nombre` varchar(255) NOT NULL,
  `fecha` date NOT NULL,
  `estado` varchar(255) NOT NULL,
  `precio` float NOT NULL,
  `descuento` varchar(255) NOT NULL,
  `garantia` int(11) NOT NULL,
  `cantidad` int(11) NOT NULL,
  PRIMARY KEY (`idpusado`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `pusados`
--

INSERT INTO `pusados` (`idpusado`, `nombre`, `fecha`, `estado`, `precio`, `descuento`, `garantia`, `cantidad`) VALUES
('PU2436783', 'ventiladores 12v', '2012-10-02', 'un 10% de uso', 12, '10', 1, 25),
('PU42723426', 'cpmpresor 15v', '2012-10-02', '10% usado', 75, '10', 1, 10),
('PU76946185', 'ventilador 15v', '2012-10-02', '80% usado', 10, '0', 0, 5),
('PU85745410', 'filtros', '2012-03-13', '70% ', 10, '5', 0, 50);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sucursal`
--

CREATE TABLE IF NOT EXISTS `sucursal` (
  `idsucursal` varchar(255) NOT NULL,
  `Nombre` varchar(255) NOT NULL,
  `Direccion` varchar(255) NOT NULL,
  `Telefono` varchar(8) NOT NULL,
  `Gerente` varchar(255) NOT NULL,
  PRIMARY KEY (`idsucursal`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `sucursal`
--

INSERT INTO `sucursal` (`idsucursal`, `Nombre`, `Direccion`, `Telefono`, `Gerente`) VALUES
('Su1002011', 'santa ana', '78 ave sur .. metrocentro santa ana', '22620282', 'Rolando Arriaza'),
('Su1003011', 'San salvador', '79 ave norte ', '22741597', 'Essau Villatoro'),
('Su1012011', 'Soyapango', 'soyapango centro ', '22845566', 'Herberth Gonzales');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `telefono`
--

CREATE TABLE IF NOT EXISTS `telefono` (
  `idtelefono` int(11) NOT NULL,
  `numero_casa` varchar(8) DEFAULT NULL,
  `numero_celular` varchar(8) DEFAULT NULL,
  PRIMARY KEY (`idtelefono`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `telefono`
--

INSERT INTO `telefono` (`idtelefono`, `numero_casa`, `numero_celular`) VALUES
(6183295, '22741597', NULL),
(9567778, '22566222', NULL),
(9584862, '22620282', NULL),
(16214391, '', NULL),
(45267955, '22645628', NULL),
(47523049, '', NULL),
(55344886, '', NULL),
(63838177, '22620282', NULL),
(72373133, '', NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `User_login`
--

CREATE TABLE IF NOT EXISTS `User_login` (
  `iduser` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `email` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `password` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `estado` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `tipo` varchar(255) COLLATE latin1_general_ci NOT NULL,
  PRIMARY KEY (`iduser`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci AUTO_INCREMENT=33 ;

--
-- Volcado de datos para la tabla `User_login`
--

INSERT INTO `User_login` (`iduser`, `username`, `email`, `password`, `estado`, `tipo`) VALUES
(32, 'rolignu2', '', 'linux', '1', 'admin'),
(2, 'root', '', 'linux', '1', 'root'),
(5, 'herberth', '', 'linux', '1', 'root'),
(30, 'user', '', 'linux', '1', 'user'),
(31, 'rolignu', 'rolignu90@gmail.com', 'linux', '1', 'root');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ventas`
--

CREATE TABLE IF NOT EXISTS `ventas` (
  `id_ventas` varchar(255) NOT NULL,
  `id_clientes` varchar(255) NOT NULL,
  `total_ventas` varchar(255) NOT NULL,
  PRIMARY KEY (`id_ventas`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
