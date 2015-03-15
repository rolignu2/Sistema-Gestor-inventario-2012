-- phpMyAdmin SQL Dump
-- version 3.5.7
-- http://www.phpmyadmin.net
--
-- Servidor: db4free.net:3306
-- Tiempo de generación: 30-03-2013 a las 19:51:24
-- Versión del servidor: 5.6.10
-- Versión de PHP: 5.3.10-1ubuntu3.6

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";

--
-- Base de datos: `delatorrebdd`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `actividades`
--

CREATE TABLE `actividades` (
  `idactividades` int(11) NOT NULL AUTO_INCREMENT,
  `actividad` varchar(255) NOT NULL,
  `fecha` date NOT NULL,
  `hora` time NOT NULL,
  `idempleado` varchar(255) NOT NULL,
  PRIMARY KEY (`idactividades`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=3 ;

--
-- Volcado de datos para la tabla `actividades`
--

INSERT INTO `actividades` (`idactividades`, `actividad`, `fecha`, `hora`, `idempleado`) VALUES
(1, 'Prod: Nuevo eq10 vendido', '2013-03-01', '00:00:00', 'EMPRO2800'),
(2, 'Prod: Nuevo eq10 vendido', '2013-03-22', '00:00:00', 'EMPRO2800');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `clientes`
--

CREATE TABLE `clientes` (
  `idcliente` varchar(255) NOT NULL,
  `nombre` text NOT NULL,
  `telefono` text NOT NULL,
  `dui` text,
  `direccion` text,
  `fecha` date NOT NULL,
  PRIMARY KEY (`idcliente`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `clientes`
--

INSERT INTO `clientes` (`idcliente`, `nombre`, `telefono`, `dui`, `direccion`, `fecha`) VALUES
('CLT10120845', 'rolando', '2262-0282', '4556-6665', '', '2013-03-25'),
('CLT15521183', 'fernando', '2274-1597', '5454-5454', '', '2013-03-25'),
('CLT29824036', 'mauricio', '7667-5881', '    -', '', '2013-03-26');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `Devolucion`
--

CREATE TABLE `Devolucion` (
  `id_devolucion` varchar(255) NOT NULL,
  `idfactura` varchar(255) NOT NULL,
  `fecha` date NOT NULL,
  `estado` bit(1) NOT NULL,
  PRIMARY KEY (`id_devolucion`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `empleados`
--

CREATE TABLE `empleados` (
  `idempleado` varchar(255) NOT NULL,
  `idusuario` varchar(255) DEFAULT NULL,
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
('EMP92202222', '32', 'rolando antonio', 'arrriaza marroquin', '4455663366-5', 1500, 'Su1003011', 'administrador', b'1'),
('EMPDS0733', 'douglas21508', 'douglas', 'palacios', '45455552-2', 400, 'Su1012011', 'Empleado', b'1'),
('EMPHH7428', 'herberth247453', 'Herberth', 'Gonzales', '00225552-2', 1500, 'Su1002011', 'Gerente', b'1'),
('EMPHO6753', 'herberth71737', 'Herberth Antonio', 'Gonzalez Hernandez', '03923763-4', 500, 'Su1003011', 'Gerente', b'1'),
('EMPM 1141', 'tulio74640', 'Marco ', 'Tulito', '44444444-4', 444, 'Su1002011', 'Cajero', b'1'),
('EMPP 7504', 'peter20443', 'Peter ', 'jarkin', '55666655-6', 350, 'SUC-SAN SALVADOR', 'Supervisor', b'1'),
('EMPRO2800', 'rolignu86255', 'Rolando Antonio', 'Arriaza Marroquin', '55665865-6', 1000, 'Su1002011', 'Gerente', b'1');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `Factura`
--

CREATE TABLE `Factura` (
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
-- Estructura de tabla para la tabla `Notificacion`
--

CREATE TABLE `Notificacion` (
  `idnotificacion` varchar(255) NOT NULL,
  `Notificacion` varchar(255) NOT NULL,
  `Hora` time NOT NULL,
  `Fecha` date NOT NULL,
  `idusuario` varchar(255) NOT NULL,
  `prioridad` int(11) DEFAULT NULL,
  PRIMARY KEY (`idnotificacion`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `Notificacion`
--

INSERT INTO `Notificacion` (`idnotificacion`, `Notificacion`, `Hora`, `Fecha`, `idusuario`, `prioridad`) VALUES
('NTN102', 'Sesion Iniciada', '23:17:42', '2013-02-26', '2', 0),
('NTN159', 'Sesion Iniciada', '18:54:36', '2013-02-28', '2', 0),
('NTN165', 'Sesion Iniciada', '16:26:30', '2013-02-26', '2', 0),
('NTN170', 'Sesion Iniciada', '23:25:58', '2013-02-26', '2', 0),
('NTN191', 'Sesion Iniciada', '09:25:44', '2013-02-26', '2', 0),
('NTN228', 'Sesion Iniciada', '09:59:18', '2013-02-26', '2', 0),
('NTN233', 'Sesion Iniciada', '15:11:20', '2013-02-27', '2', 0),
('NTN239', 'Sesion Iniciada', '18:56:23', '2013-02-28', '2', 0),
('NTN250', 'Cerro sesion ', '16:41:39', '2013-02-26', '2', 1),
('NTN275', 'Sesion Iniciada', '15:01:43', '2013-02-27', '30', 0),
('NTN284', 'Sesion Iniciada', '20:53:26', '2013-02-27', '2', 0),
('NTN293', 'Sesion Iniciada', '11:50:46', '2013-02-26', '2', 0),
('NTN295', 'Sesion Iniciada', '12:13:03', '2013-02-26', '2', 0),
('NTN347', 'Sesion Iniciada', '11:30:02', '2013-02-26', '2', 0),
('NTN36', 'Sesion Iniciada', '12:01:39', '2013-02-26', '2', 0),
('NTN360', 'Sesion Iniciada', '16:30:38', '2013-02-26', '2', 0),
('NTN376', 'Sesion Iniciada', '23:30:33', '2013-02-26', '30', 0),
('NTN379', 'Sesion Iniciada', '15:08:59', '2013-02-27', '30', 0),
('NTN396', 'Sesion Iniciada', '12:09:45', '2013-02-26', '2', 0),
('NTN4', 'Sesion Iniciada', '20:46:20', '2013-02-27', '2', 0),
('NTN408', 'Sesion Iniciada', '20:55:42', '2013-02-27', '2', 0),
('NTN428', 'Sesion Iniciada', '16:41:05', '2013-02-26', '2', 0),
('NTN439', 'Sesion Iniciada', '11:44:49', '2013-02-26', '2', 0),
('NTN44', 'Sesion Iniciada', '09:52:23', '2013-02-26', '2', 0),
('NTN440', 'Sesion Iniciada', '09:29:58', '2013-02-26', '2', 0),
('NTN470', 'Nuevo producto agregado PKS10010045 marihuana ', '19:00:44', '2013-02-28', '2', 2),
('NTN486', 'Sesion Iniciada', '23:01:10', '2013-02-26', '2', 0),
('NTN490', 'Sesion Iniciada', '18:33:59', '2013-02-27', '2', 0),
('NTN493', 'Sesion Iniciada', '16:31:28', '2013-02-26', '2', 0),
('NTN497', 'Sesion Iniciada', '12:16:18', '2013-02-26', '2', 0),
('NTN507', 'Sesion Iniciada', '11:33:02', '2013-02-26', '2', 0),
('NTN527', 'Sesion Iniciada', '20:49:54', '2013-02-27', '2', 0),
('NTN542', 'Sesion Iniciada', '16:23:14', '2013-02-26', '2', 0),
('NTN55', 'Sesion Iniciada', '11:40:11', '2013-02-26', '2', 0),
('NTN552', 'Sesion Iniciada', '14:59:09', '2013-02-27', '2', 0),
('NTN553', 'Sesion Iniciada', '11:38:22', '2013-02-26', '2', 0),
('NTN569', 'Sesion Iniciada', '10:02:16', '2013-02-26', '2', 0),
('NTN57', 'Nuevo producto agregado PKS100100 marihuana ', '18:58:25', '2013-02-28', '2', 2),
('NTN591', 'Sesion Iniciada', '22:57:34', '2013-02-26', '2', 0),
('NTN616', 'Cerro sesion ', '09:33:07', '2013-02-26', '2', 1),
('NTN650', 'Sesion Iniciada', '14:07:45', '2013-02-27', '2', 0),
('NTN674', 'Sesion Iniciada', '23:27:15', '2013-02-26', '30', 0),
('NTN692', 'Sesion Iniciada', '23:19:00', '2013-02-26', '2', 0),
('NTN7', 'Sesion Iniciada', '10:00:23', '2013-02-26', '2', 0),
('NTN722', 'Sesion Iniciada', '14:11:15', '2013-02-26', '2', 0),
('NTN748', 'Sesion Iniciada', '20:52:07', '2013-02-27', '2', 0),
('NTN752', 'Sesion Iniciada', '23:06:26', '2013-02-26', '2', 0),
('NTN755', 'Sesion Iniciada', '12:19:13', '2013-02-26', '2', 0),
('NTN779', 'Cerro sesion ', '15:03:21', '2013-02-27', '30', 1),
('NTN800', 'Sesion Iniciada', '20:30:54', '2013-02-27', '2', 0),
('NTN822', 'Sesion Iniciada', '20:13:13', '2013-02-27', '2', 0),
('NTN835', 'Sesion Iniciada', '16:39:43', '2013-02-26', '2', 0),
('NTN840', 'Sesion Iniciada', '15:02:44', '2013-02-27', '30', 0),
('NTN874', 'Sesion Iniciada', '11:42:05', '2013-02-26', '2', 0),
('NTN884', 'Sesion Iniciada', '23:20:32', '2013-02-26', '2', 0),
('NTN895', 'Sesion Iniciada', '17:14:51', '2013-02-27', '2', 0),
('NTN908', 'Sesion Iniciada', '11:21:44', '2013-02-26', '2', 0),
('NTN911', 'Sesion Iniciada', '14:12:12', '2013-02-27', '2', 0),
('NTN923', 'Cerro sesion ', '20:09:25', '2013-02-27', '2', 1),
('NTN954', 'Sesion Iniciada', '20:48:30', '2013-02-27', '2', 0),
('NTN971', 'Sesion Iniciada', '11:27:07', '2013-02-26', '2', 0),
('NTNP10026028881', 'Sesion Iniciada', '17:52:11', '2013-03-22', 'rolignu86255', 0),
('NTNP104783608378', 'Cerro sesion ', '12:54:25', '2013-03-15', 'rolignu86255', 1),
('NTNP106648357573', 'Sesion Iniciada', '10:49:16', '2013-03-05', 'rolignu86255', 0),
('NTNP109102273979', 'Sesion Iniciada', '11:49:54', '2013-03-05', 'rolignu86255', 0),
('NTNP114420937580', 'Sesion Iniciada', '12:38:17', '2013-03-26', 'rolignu86255', 0),
('NTNP11521421685', 'Sesion Iniciada', '21:16:16', '2013-03-22', 'rolignu86255', 0),
('NTNP11866793692', 'Producto PN2222 Ha sido eliminado de la lista ', '11:34:22', '2013-03-14', 'herberth71737', 5),
('NTNP118873853986', 'Sesion Iniciada', '22:18:48', '2013-03-14', 'rolignu86255', 0),
('NTNP121327768392', 'Sesion Iniciada', '22:49:07', '2013-03-02', 'herberth71737', 0),
('NTNP12157896118', 'Sesion Iniciada', '19:02:00', '2013-03-01', '30', 0),
('NTNP123191517587', 'Sesion Iniciada', '12:17:56', '2013-03-05', 'rolignu86255', 0),
('NTNP125850350888', 'Sesion Iniciada', '14:41:34', '2013-03-27', 'rolignu86255', 0),
('NTNP13016914490', 'Sesion Iniciada', '16:37:55', '2013-03-16', 'rolignu86255', 0),
('NTNP13196298595', 'Sesion Iniciada', '10:57:55', '2013-03-14', 'rolignu86255', 0),
('NTNP132757181700', 'Sesion Iniciada', '16:52:43', '2013-03-01', 'herberth71737', 0),
('NTNP1374564329', 'producto agregado Cod:(PNNDSD ) Nombre: dad', '12:16:41', '2013-03-22', 'rolignu86255', 2),
('NTNP139734677602', 'Sesion Iniciada', '14:37:11', '2013-03-25', 'rolignu86255', 0),
('NTNP142393510902', 'Cerro sesion ', '23:35:49', '2013-03-02', 'herberth71737', 1),
('NTNP14453342203', 'Sesion Iniciada', '18:59:37', '2013-03-14', 'rolignu86255', 0),
('NTNP147711174504', 'Sesion Iniciada', '11:11:41', '2013-03-05', 'rolignu86255', 0),
('NTNP148576922699', 'Sesion Iniciada', '16:43:36', '2013-03-01', '32', 0),
('NTNP1493707804', 'Sesion Iniciada', '20:57:39', '2013-02-28', '2', 0),
('NTNP15230838106', 'Sesion Iniciada', '15:14:22', '2013-03-28', 'rolignu86255', 0),
('NTNP15610812524', 'Cerro sesion ', '12:01:27', '2013-03-05', 'rolignu86255', 1),
('NTNP157348503706', 'Sesion Iniciada', '14:50:41', '2013-03-14', 'rolignu86255', 0),
('NTNP158142586811', 'Sesion Iniciada', '12:48:05', '2013-03-09', 'herberth71737', 0),
('NTNP15973358', 'Sesion Iniciada', '23:23:12', '2013-03-19', 'rolignu86255', 0),
('NTNP161595502218', 'Cerro sesion ', '20:14:28', '2013-03-01', '2', 1),
('NTNP162665168308', 'Sesion Iniciada', '18:41:23', '2013-03-22', 'rolignu86255', 0),
('NTNP16404896629', 'Sesion Iniciada', '17:21:17', '2013-03-02', '32', 0),
('NTNP16511984714', 'Sesion Iniciada', '12:20:18', '2013-03-05', 'rolignu86255', 0),
('NTNP16777891515', 'Sesion Iniciada', '18:11:56', '2013-03-02', '5', 0),
('NTNP1726484810', 'Producto PU200566 Ha sido eliminado de la lista ', '10:42:27', '2013-03-02', 'rolignu86255', 5),
('NTNP173890663721', 'Sesion Iniciada', '12:46:27', '2013-03-05', 'rolignu86255', 0),
('NTNP174685747826', 'Sesion Iniciada', '20:41:19', '2013-03-10', 'rolignu86255', 0),
('NTNP178209328322', 'Sesion Iniciada', '11:18:11', '2013-03-05', 'rolignu86255', 0),
('NTNP181867160623', 'Cerro sesion ', '22:18:37', '2013-03-23', 'rolignu86255', 1),
('NTNP182662244728', 'Sesion Iniciada', '21:25:36', '2013-02-28', '2', 0),
('NTNP1843217629', 'Sesion Iniciada', '23:52:32', '2013-03-14', 'rolignu86255', 0),
('NTNP187979907330', 'producto agregado Cod:(PU2005633 ) Nombre: agua cristal', '10:50:07', '2013-03-02', 'rolignu86255', 2),
('NTNP188844656525', 'Sesion Iniciada', '10:59:11', '2013-03-05', 'rolignu86255', 0),
('NTNP189639740630', 'Cerro sesion ', '19:59:11', '2013-03-01', '30', 1),
('NTNP192298572930', 'Sesion Iniciada', '14:32:37', '2013-03-14', 'rolignu86255', 0),
('NTNP1929365636', 'Cerro sesion ', '22:42:50', '2013-02-28', '2', 1),
('NTNP197616237532', 'Sesion Iniciada', '21:13:12', '2013-03-14', 'rolignu86255', 0),
('NTNP202728984239', 'Sesion Iniciada', '23:10:39', '2013-03-23', 'rolignu86255', 0),
('NTNP202934901134', 'Sesion Iniciada', '21:35:20', '2013-02-28', '2', 0),
('NTNP205388816539', 'Sesion Iniciada', '15:42:58', '2013-03-23', 'rolignu86255', 0),
('NTNP206253565735', 'Sesion Iniciada', '16:43:02', '2013-03-01', '30', 0),
('NTNP211500565246', 'Cerro sesion ', '14:33:56', '2013-03-04', 'rolignu86255', 1),
('NTNP212365313441', 'Sesion Iniciada', '18:33:14', '2013-03-01', '2', 0),
('NTNP213159397546', 'Cerro sesion ', '16:52:32', '2013-03-01', '2', 1),
('NTNP21524146742', 'Sesion Iniciada', '12:49:02', '2013-03-15', 'rolignu86255', 0),
('NTNP216818229847', 'Sesion Iniciada', '21:38:15', '2013-03-14', 'rolignu86255', 0),
('NTNP21768397743', 'Sesion Iniciada', '18:43:45', '2013-03-01', '2', 0),
('NTNP220342810343', 'Sesion Iniciada', '23:07:42', '2013-03-23', 'rolignu86255', 0),
('NTNP221137893449', 'Sesion Iniciada', '15:26:40', '2013-03-28', 'rolignu86255', 0),
('NTNP2221642644', 'Sesion Iniciada', '23:07:37', '2013-03-02', '32', 0),
('NTNP22587309426', 'Sesion Iniciada', '22:48:29', '2013-03-02', '32', 0),
('NTNP22645455850', 'Sesion Iniciada', '17:39:33', '2013-03-02', '32', 0),
('NTNP228114390351', 'Sesion Iniciada', '14:39:33', '2013-03-14', 'rolignu86255', 0),
('NTNP231567306756', 'producto agregado Cod:(PUS123356 ) Nombre: cacao', '10:43:12', '2013-02-28', '2', 2),
('NTNP231772222651', 'Sesion Iniciada', '15:38:09', '2013-03-23', 'rolignu86255', 0),
('NTNP23422613857', 'Sesion Iniciada', '21:34:13', '2013-03-22', 'rolignu86255', 0),
('NTNP23521222162', 'Producto PU100105 Ha sido eliminado de la lista ', '14:50:55', '2013-03-14', 'rolignu86255', 5),
('NTNP238749719553', 'producto agregado Cod:(PN456636 ) Nombre: canon laser', '11:11:32', '2013-03-21', 'rolignu86255', 2),
('NTNP240338885763', 'Sesion Iniciada', '21:32:37', '2013-02-28', '2', 0),
('NTNP241203634959', 'Sesion Iniciada', '11:22:18', '2013-03-05', 'rolignu86255', 0),
('NTNP246521299560', 'Sesion Iniciada', '16:41:42', '2013-03-01', '2', 0),
('NTNP247316383665', 'Sesion Iniciada', '21:19:36', '2013-03-01', '2', 0),
('NTNP25246142726', 'producto agregado Cod:(PU200566 ) Nombre: chatarra barata', '21:05:03', '2013-02-28', '2', 2),
('NTNP253428131372', 'Cerro sesion ', '23:53:13', '2013-03-14', 'rolignu86255', 1),
('NTNP25587962672', 'producto agregado Cod:(PU100105 ) Nombre: condensadro 45pf', '23:33:26', '2013-03-15', 'rolignu86255', 2),
('NTNP260611543169', 'Cerro sesion ', '15:37:04', '2013-03-16', 'rolignu86255', 1),
('NTNP262270376470', 'Sesion Iniciada', '13:52:58', '2013-03-25', 'rolignu86255', 0),
('NTNP265723292875', 'Sesion Iniciada', '21:44:06', '2013-03-14', 'rolignu86255', 0),
('NTNP265928208770', 'Cerro sesion ', '21:03:14', '2013-03-01', '2', 1),
('NTNP27183540582', 'Cerro sesion ', '21:25:04', '2013-03-01', '2', 1),
('NTNP273700788777', 'Cerro sesion ', '17:07:06', '2013-03-26', 'rolignu86255', 1),
('NTNP274495871882', 'Cerro sesion ', '20:06:45', '2013-03-18', 'rolignu86255', 1),
('NTNP2790597328', 'Sesion Iniciada', '18:01:56', '2013-03-01', '2', 0),
('NTNP279607619589', 'Sesion Iniciada', '22:58:04', '2013-03-02', '32', 0),
('NTNP284925284191', 'Sesion Iniciada', '18:59:31', '2013-03-14', 'rolignu86255', 0),
('NTNP28679033386', 'Sesion Iniciada', '12:02:37', '2013-03-05', 'rolignu86255', 0),
('NTNP291108697987', 'Sesion Iniciada', '18:45:53', '2013-03-14', 'rolignu86255', 0),
('NTNP29494141238', 'Producto PUS123356 Ha sido eliminado de la lista ', '20:10:21', '2013-03-01', '2', 5),
('NTNP295356696498', 'Sesion Iniciada', '21:24:51', '2013-03-01', '2', 0),
('NTNP300674361100', 'producto agregado Cod:(PN666 ) Nombre: producto prueba decimal', '12:48:03', '2013-03-05', 'rolignu86255', 2),
('NTNP30564805328', 'Sesion Iniciada', '18:08:14', '2013-03-02', '32', 0),
('NTNP310310689302', 'Sesion Iniciada', '16:40:26', '2013-03-16', 'rolignu86255', 0),
('NTNP313763605708', 'Sesion Iniciada', '21:17:07', '2013-03-01', '32', 0),
('NTNP313968522603', 'Sesion Iniciada', '12:41:15', '2013-03-26', 'rolignu86255', 0),
('NTNP314833270798', 'Cerro sesion ', '11:39:43', '2013-03-05', 'rolignu86255', 1),
('NTNP315628354903', 'Sesion Iniciada', '19:04:20', '2013-03-14', 'rolignu86255', 0),
('NTNP318287186205', 'Sesion Iniciada', '20:03:51', '2013-03-18', 'rolignu86255', 0),
('NTNP31882270310', 'Sesion Iniciada', '21:51:27', '2013-03-23', 'rolignu86255', 0),
('NTNP321740102610', 'Sesion Iniciada', '12:48:09', '2013-03-15', 'rolignu86255', 0),
('NTNP323605850805', 'Producto PN56666 Ha sido eliminado de la lista ', '12:47:33', '2013-03-05', 'rolignu86255', 5),
('NTNP327853849317', 'producto agregado Cod:(fsds ) Nombre: sd', '14:39:31', '2013-03-04', 'rolignu86255', 2),
('NTNP328923515407', 'Sesion Iniciada', '23:15:24', '2013-03-02', 'rolignu86255', 0),
('NTNP329512682617', 'Producto PN96241130 Ha sido eliminado de la lista ', '18:37:52', '2013-03-01', '2', 5),
('NTNP33336263114', 'Sesion Iniciada', '12:07:49', '2013-02-28', '2', 0),
('NTNP33914811820', 'Sesion Iniciada', '22:36:40', '2013-03-05', 'rolignu86255', 0),
('NTNP344466675421', 'Sesion Iniciada', '23:44:58', '2013-03-14', 'rolignu86255', 0),
('NTNP34811805839', 'Sesion Iniciada', '14:51:04', '2013-03-14', 'rolignu86255', 0),
('NTNP348919591827', 'Sesion Iniciada', '11:15:12', '2013-03-05', 'rolignu86255', 0),
('NTNP34978434023', 'Sesion Iniciada', '11:47:10', '2013-03-22', 'rolignu86255', 0),
('NTNP350579423128', 'Sesion Iniciada', '10:39:10', '2013-03-05', 'rolignu86255', 0),
('NTNP356691171834', 'Cerro sesion ', '17:54:02', '2013-03-01', '2', 1),
('NTNP357761836924', 'Sesion Iniciada', '11:07:49', '2013-03-02', 'herberth71737', 0),
('NTNP3583504135', 'Sesion Iniciada', '11:02:35', '2013-03-21', 'rolignu86255', 0),
('NTNP360215751331', 'Sesion Iniciada', '14:19:05', '2013-03-15', 'rolignu86255', 0),
('NTNP362874584631', 'Sesion Iniciada', '21:23:11', '2013-03-01', '32', 0),
('NTNP363668667736', 'producto agregado Cod:(PN4555 ) Nombre: prueba', '16:32:12', '2013-03-14', 'herberth71737', 2),
('NTNP3667655435', 'Sesion Iniciada', '19:06:36', '2013-03-14', 'rolignu86255', 0),
('NTNP368986332338', 'Sesion Iniciada', '21:24:44', '2013-03-22', 'rolignu86255', 0),
('NTNP371645164638', 'Sesion Iniciada', '21:08:47', '2013-03-15', 'rolignu86255', 0),
('NTNP373305996939', 'Sesion Iniciada', '14:12:28', '2013-03-25', 'rolignu86255', 0),
('NTNP376963828240', 'Sesion Iniciada', '18:59:44', '2013-03-14', 'rolignu86255', 0),
('NTNP377758912345', 'Sesion Iniciada', '12:54:18', '2013-03-15', 'rolignu86255', 0),
('NTNP381282493841', 'Sesion Iniciada', '12:43:35', '2013-03-05', 'rolignu86255', 0),
('NTNP38336386335', 'Cerro sesion ', '18:11:47', '2013-03-02', '5', 1),
('NTNP383940325142', 'Sesion Iniciada', '21:15:23', '2013-03-15', 'rolignu86255', 0),
('NTNP384735409247', 'Sesion Iniciada', '20:41:38', '2013-03-10', 'rolignu86255', 0),
('NTNP386600158442', 'Sesion Iniciada', '14:42:42', '2013-03-14', 'rolignu86255', 0),
('NTNP387189325652', 'Sesion Iniciada', '21:40:15', '2013-03-14', 'rolignu86255', 0),
('NTNP387394241547', 'Sesion Iniciada', '21:18:27', '2013-03-15', 'rolignu86255', 0),
('NTNP38896171476', 'Sesion Iniciada', '11:23:49', '2013-03-01', '2', 0),
('NTNP39130469440', 'Nuevo producto agregado Cod:(PN20020510 ) Nombre: hielo frio :3', '19:11:11', '2013-02-28', '2', 2),
('NTNP392506988254', 'Producto PN20020510 Ha sido eliminado de la lista ', '10:32:50', '2013-03-02', 'rolignu86255', 5),
('NTNP392712905149', 'Sesion Iniciada', '21:45:14', '2013-02-28', '2', 0),
('NTNP395166821555', 'Sesion Iniciada', '23:33:56', '2013-03-14', 'rolignu86255', 0),
('NTNP39631569750', 'Sesion Iniciada', '19:06:38', '2013-03-14', 'rolignu86255', 0),
('NTNP398619736960', 'Sesion Iniciada', '21:28:46', '2013-02-28', '2', 0),
('NTNP400484485156', 'Sesion Iniciada', '16:10:45', '2013-03-29', 'rolignu86255', 0),
('NTNP401348234352', 'Sesion Iniciada', '12:46:11', '2013-03-09', 'herberth71737', 0),
('NTNP402143318457', 'Sesion Iniciada', '16:17:22', '2013-03-14', 'rolignu86255', 0),
('NTNP403937401562', 'Sesion Iniciada', '11:12:50', '2013-03-02', 'rolignu86255', 0),
('NTNP405801150757', 'Sesion Iniciada', '10:59:26', '2013-03-05', 'rolignu86255', 0),
('NTNP412779646659', 'Sesion Iniciada', '14:42:24', '2013-03-04', 'rolignu86255', 0),
('NTNP415438478960', 'Sesion Iniciada', '12:47:25', '2013-03-09', 'herberth71737', 0),
('NTNP41789302741', 'Cerro sesion ', '18:12:06', '2013-03-02', '5', 1),
('NTNP41797311261', 'Sesion Iniciada', '16:31:22', '2013-03-16', 'rolignu86255', 0),
('NTNP421345310771', 'Sesion Iniciada', '18:35:20', '2013-03-22', 'rolignu86255', 0),
('NTNP421550227666', 'Sesion Iniciada', '11:50:43', '2013-02-28', '2', 0),
('NTNP424414373', 'Sesion Iniciada', '21:22:06', '2013-02-28', '2', 0),
('NTNP426868890268', 'Sesion Iniciada', '12:00:52', '2013-03-14', 'rolignu86255', 0),
('NTNP42745758478', 'Cerro sesion ', '23:59:43', '2013-03-15', 'rolignu86255', 1),
('NTNP430117890779', 'Cerro sesion ', '11:50:26', '2013-03-05', 'rolignu86255', 1),
('NTNP431187555869', 'Sesion Iniciada', '15:27:41', '2013-03-16', 'rolignu86255', 0),
('NTNP433845388170', 'Sesion Iniciada', '23:35:00', '2013-03-19', 'rolignu86255', 0),
('NTNP436299303576', 'Sesion Iniciada', '13:50:11', '2013-03-05', 'rolignu86255', 0),
('NTNP4365351936', 'Sesion Iniciada', '15:06:15', '2013-03-28', 'rolignu86255', 0),
('NTNP43794387681', 'Sesion Iniciada', '20:32:15', '2013-03-01', '2', 0),
('NTNP440752219981', 'Sesion Iniciada', '22:51:56', '2013-03-05', 'rolignu86255', 0),
('NTNP443206135387', 'Sesion Iniciada', '12:01:54', '2013-03-22', 'rolignu86255', 0),
('NTNP446935632778', 'Sesion Iniciada', '12:20:51', '2013-03-05', 'rolignu86255', 0),
('NTNP448524799988', 'Sesion Iniciada', '12:45:04', '2013-03-15', 'rolignu86255', 0),
('NTNP44959446480', 'Sesion Iniciada', '18:20:45', '2013-03-14', 'rolignu86255', 0),
('NTNP450183631290', 'Cerro sesion ', '18:02:29', '2013-03-02', 'herberth71737', 1),
('NTNP45243218147', 'Sesion Iniciada', '14:23:26', '2013-03-15', 'rolignu86255', 0),
('NTNP453842463590', 'Sesion Iniciada', '21:44:53', '2013-03-15', 'rolignu86255', 0),
('NTNP460819960492', 'Sesion Iniciada', '22:51:58', '2013-03-05', 'rolignu86255', 0),
('NTNP466931708199', 'Sesion Iniciada', '23:52:24', '2013-03-14', 'rolignu86255', 0),
('NTNP469590540499', 'producto agregado Cod:(PN2002336 ) Nombre: CALENTADOR', '16:19:27', '2013-03-29', 'rolignu86255', 2),
('NTNP471250372800', 'Cerro sesion ', '19:07:54', '2013-03-14', 'rolignu86255', 1),
('NTNP473115121995', 'producto agregado Cod:(PU55664 ) Nombre: tuercas varias 5mm', '23:52:45', '2013-03-15', 'rolignu86255', 2),
('NTNP475773953296', 'Sesion Iniciada', '12:12:02', '2013-03-14', 'rolignu86255', 0),
('NTNP47656837401', 'Sesion Iniciada', '13:36:21', '2013-03-28', 'rolignu86255', 0),
('NTNP4818857013', 'Sesion Iniciada', '18:48:14', '2013-03-14', 'rolignu86255', 0),
('NTNP482680784108', 'producto agregado Cod:(PNKSSSSS ) Nombre: canilla', '11:33:42', '2013-03-05', 'rolignu86255', 2),
('NTNP484339617409', 'Sesion Iniciada', '21:40:11', '2013-03-14', 'rolignu86255', 0),
('NTNP484545533303', 'Sesion Iniciada', '18:45:55', '2013-03-14', 'rolignu86255', 0),
('NTNP486204366604', 'Sesion Iniciada', '12:20:14', '2013-03-05', 'rolignu86255', 0),
('NTNP487998449709', 'Cerro sesion ', '20:54:29', '2013-03-01', '2', 1),
('NTNP490452365115', 'producto agregado Cod:(PN45 ) Nombre: bbb', '15:29:39', '2013-03-15', 'rolignu86255', 2),
('NTNP492316114311', 'producto agregado Cod:(PN4556633 ) Nombre: nalga pacha', '12:15:20', '2013-03-05', 'rolignu86255', 2),
('NTNP493111197416', 'Sesion Iniciada', '11:58:03', '2013-03-05', 'rolignu86255', 0),
('NTNP49766798643', 'Sesion Iniciada', '19:06:12', '2013-03-14', 'rolignu86255', 0),
('NTNP505406358919', 'Producto PN2499520555 Ha sido eliminado de la lista ', '20:08:53', '2013-03-01', '2', 5),
('NTNP50620144225', 'Sesion Iniciada', '22:52:33', '2013-03-02', '32', 0),
('NTNP507271107115', 'Sesion Iniciada', '23:47:03', '2013-03-14', 'rolignu86255', 0),
('NTNP50865190220', 'Sesion Iniciada', '23:52:26', '2013-03-14', 'rolignu86255', 0),
('NTNP51072423520', 'Sesion Iniciada', '15:33:43', '2013-03-28', 'rolignu86255', 0),
('NTNP511518106625', 'Sesion Iniciada', '18:53:33', '2013-03-01', '30', 0),
('NTNP513178938926', 'Sesion Iniciada', '20:34:31', '2013-03-01', '2', 0),
('NTNP51543687122', 'Sesion Iniciada', '18:06:38', '2013-03-26', 'rolignu86255', 0),
('NTNP517631854332', 'Cerro sesion ', '20:11:28', '2013-03-18', 'peter20443', 1),
('NTNP520360351723', 'Sesion Iniciada', '11:38:03', '2013-03-05', 'rolignu86255', 0),
('NTNP522948518933', 'Sesion Iniciada', '16:51:13', '2013-03-01', '2', 0),
('NTNP524608351234', 'Sesion Iniciada', '21:50:44', '2013-03-22', 'rolignu86255', 0),
('NTNP52647399430', 'Cerro sesion ', '19:42:04', '2013-02-28', '2', 1),
('NTNP527267183535', 'Sesion Iniciada', '21:47:23', '2013-03-22', 'rolignu86255', 0),
('NTNP528132931730', 'Cerro sesion ', '16:42:49', '2013-03-01', '2', 1),
('NTNP53179076331', 'Sesion Iniciada', '16:17:28', '2013-03-14', 'rolignu86255', 0),
('NTNP534244679437', 'Sesion Iniciada', '20:04:28', '2013-03-01', '2', 0),
('NTNP537903511737', 'Sesion Iniciada', '17:53:14', '2013-03-01', '2', 0),
('NTNP53956234438', 'Sesion Iniciada', '12:21:50', '2013-03-05', 'rolignu86255', 0),
('NTNP5448809639', 'Sesion Iniciada', '18:11:14', '2013-03-26', 'rolignu86255', 0),
('NTNP54567492744', 'Sesion Iniciada', '21:28:24', '2013-03-22', 'rolignu86255', 0),
('NTNP547539840940', 'Sesion Iniciada', '12:48:07', '2013-03-05', 'rolignu86255', 0),
('NTNP5481288151', 'Sesion Iniciada', '12:21:01', '2013-03-05', 'rolignu86255', 0),
('NTNP549199672241', 'Sesion Iniciada', '16:08:27', '2013-03-29', 'rolignu86255', 0),
('NTNP551787839451', 'Sesion Iniciada', '18:37:29', '2013-03-01', '2', 0),
('NTNP552652588646', 'Producto PN45 Ha sido eliminado de la lista ', '17:44:11', '2013-03-16', 'rolignu86255', 5),
('NTNP552857505541', 'Sesion Iniciada', '12:15:24', '2013-03-05', 'rolignu86255', 0),
('NTNP555311420947', 'Sesion Iniciada', '21:08:53', '2013-03-15', 'rolignu86255', 0),
('NTNP558764336353', 'Producto PN2055566336 Ha sido eliminado de la lista ', '11:22:17', '2013-03-05', 'rolignu86255', 5),
('NTNP55878546350', 'Cerro sesion ', '21:19:44', '2013-03-01', '2', 1),
('NTNP56062985548', 'Cerro sesion ', '18:59:49', '2013-03-01', '2', 1),
('NTNP561423169654', 'producto agregado Cod:(PU200205 ) Nombre: rabiola', '22:17:33', '2013-02-28', '2', 2),
('NTNP562218252759', 'Sesion Iniciada', '21:23:25', '2013-02-28', '2', 0),
('NTNP562288917849', 'Sesion Iniciada', '18:40:42', '2013-03-01', '2', 0),
('NTNP5648768460', 'Sesion Iniciada', '20:35:17', '2013-03-09', 'rolignu86255', 0),
('NTNP566741832255', 'producto agregado Cod:(PN10052040 ) Nombre: 455663663', '17:44:26', '2013-03-24', 'rolignu86255', 2),
('NTNP567536916360', 'Sesion Iniciada', '19:43:57', '2013-02-28', '2', 0),
('NTNP569195748661', 'Sesion Iniciada', '11:25:40', '2013-03-22', 'rolignu86255', 0),
('NTNP572853581961', 'Sesion Iniciada', '12:32:28', '2013-03-25', 'rolignu86255', 0),
('NTNP573718329157', 'Sesion Iniciada', '14:39:52', '2013-03-04', 'rolignu86255', 0),
('NTNP574513413262', 'Sesion Iniciada', '21:38:19', '2013-03-14', 'rolignu86255', 0),
('NTNP577966329668', 'Producto PROD1001223366N Ha sido eliminado de la lista ', '20:40:26', '2013-03-10', 'rolignu86255', 5),
('NTNP57837993758', 'Cerro sesion ', '16:35:01', '2013-03-14', 'rolignu86255', 1),
('NTNP57983178863', 'Cerro sesion ', '18:07:21', '2013-03-02', '32', 1),
('NTNP58169582660', 'Sesion Iniciada', '23:27:45', '2013-03-15', 'rolignu86255', 0),
('NTNP582490909165', 'Producto dfdf Ha sido eliminado de la lista ', '11:18:09', '2013-03-05', 'rolignu86255', 5),
('NTNP58332462755', 'Sesion Iniciada', '12:12:54', '2013-03-05', 'rolignu86255', 0),
('NTNP584149741465', 'Sesion Iniciada', '19:06:31', '2013-03-14', 'rolignu86255', 0),
('NTNP590262490172', 'Sesion Iniciada', '12:01:10', '2013-03-14', 'rolignu86255', 0),
('NTNP591127238367', 'Sesion Iniciada', '16:21:04', '2013-03-26', 'rolignu86255', 0),
('NTNP593715405577', 'Sesion Iniciada', '21:46:11', '2013-03-14', 'rolignu86255', 0),
('NTNP5983370179', 'Sesion Iniciada', '16:14:02', '2013-03-29', 'rolignu86255', 0),
('NTNP600897818374', 'Sesion Iniciada', '11:48:02', '2013-03-05', 'rolignu86255', 0),
('NTNP60197211950', 'Sesion Iniciada', '22:51:36', '2013-03-05', 'rolignu86255', 0),
('NTNP603351734780', 'Sesion Iniciada', '12:22:12', '2013-03-05', 'rolignu86255', 0),
('NTNP6061156681', 'Sesion Iniciada', '10:40:00', '2013-03-05', 'rolignu86255', 0),
('NTNP607874315276', 'Sesion Iniciada', '16:39:33', '2013-03-01', '2', 0),
('NTNP609464482486', 'Sesion Iniciada', '14:09:27', '2013-03-04', 'rolignu86255', 0),
('NTNP611328231682', 'Producto PNNDSD Ha sido eliminado de la lista ', '12:16:54', '2013-03-22', 'rolignu86255', 5),
('NTNP61398763982', 'Cerro sesion ', '20:57:37', '2013-03-01', '32', 1),
('NTNP616646895283', 'Sesion Iniciada', '23:52:29', '2013-03-14', 'rolignu86255', 0),
('NTNP618306727584', 'Cerro sesion ', '11:01:49', '2013-03-02', 'rolignu86255', 1),
('NTNP62255372695', 'Cerro sesion ', '16:21:32', '2013-03-29', 'rolignu86255', 1),
('NTNP624418475291', 'Sesion Iniciada', '13:43:42', '2013-03-28', 'rolignu86255', 0),
('NTNP62677308591', 'Sesion Iniciada', '23:14:07', '2013-03-23', 'rolignu86255', 0),
('NTNP62894156786', 'Sesion Iniciada', '19:28:17', '2013-02-28', '2', 0),
('NTNP630530223996', 'Sesion Iniciada', '11:31:48', '2013-03-14', 'herberth71737', 0),
('NTNP631395971193', 'Sesion Iniciada', '15:46:05', '2013-03-23', 'rolignu86255', 0),
('NTNP635848887598', 'Sesion Iniciada', '13:50:27', '2013-03-28', 'rolignu86255', 0),
('NTNP636713636794', 'Cerro sesion ', '12:26:10', '2013-03-05', 'rolignu86255', 1),
('NTNP637507719899', 'Sesion Iniciada', '23:38:03', '2013-03-23', 'rolignu86255', 0),
('NTNP640167552200', 'Sesion Iniciada', '21:36:26', '2013-03-14', 'rolignu86255', 0),
('NTNP64132301395', 'Sesion Iniciada', '22:17:15', '2013-03-14', 'rolignu86255', 0),
('NTNP643620468605', 'Sesion Iniciada', '11:08:44', '2013-03-02', 'rolignu86255', 0),
('NTNP64714449102', 'Sesion Iniciada', '23:23:01', '2013-03-23', 'rolignu86255', 0),
('NTNP650597964507', 'Cerro sesion ', '11:44:59', '2013-03-14', 'herberth71737', 1),
('NTNP65309958657', 'Sesion Iniciada', '21:03:41', '2013-02-28', '2', 0),
('NTNP65515874552', 'Sesion Iniciada', '17:36:41', '2013-03-29', 'rolignu86255', 0),
('NTNP66389212611', 'Sesion Iniciada', '18:15:41', '2013-03-01', '2', 0),
('NTNP665551957312', 'Cerro sesion ', '11:00:17', '2013-03-05', 'rolignu86255', 1),
('NTNP669799956822', 'Sesion Iniciada', '21:21:09', '2013-02-28', '2', 0),
('NTNP670869622912', 'Sesion Iniciada', '14:31:38', '2013-03-25', 'rolignu86255', 0),
('NTNP67166370518', 'Sesion Iniciada', '12:19:10', '2013-03-05', 'rolignu86255', 0),
('NTNP672458789123', 'Sesion Iniciada', '11:33:08', '2013-03-19', 'rolignu86255', 0),
('NTNP674323538319', 'Sesion Iniciada', '17:37:46', '2013-03-02', '32', 0),
('NTNP679641202920', 'Cerro sesion ', '22:38:48', '2013-03-01', '32', 1),
('NTNP683888202431', 'Sesion Iniciada', '22:36:42', '2013-03-14', 'rolignu86255', 0),
('NTNP687412782927', 'Sesion Iniciada', '18:41:43', '2013-03-14', 'rolignu86255', 0),
('NTNP68968790957', 'Cerro sesion ', '20:34:09', '2013-03-18', 'rolignu86255', 1),
('NTNP693525530634', 'Sesion Iniciada', '17:54:50', '2013-03-22', 'rolignu86255', 0),
('NTNP694390279829', 'Sesion Iniciada', '11:17:49', '2013-03-05', 'rolignu86255', 0),
('NTNP698637278340', 'Sesion Iniciada', '21:27:37', '2013-03-15', 'rolignu86255', 0),
('NTNP699707943431', 'Sesion Iniciada', '10:40:49', '2013-02-28', '2', 0),
('NTNP702367775731', 'producto agregado Cod:(TYU0120324 ) Nombre: VENTILADOR DE 1/2', '12:24:42', '2013-03-05', 'herberth247453', 2),
('NTNP705820691137', 'Sesion Iniciada', '17:47:24', '2013-03-01', '2', 0),
('NTNP70627623259', 'Sesion Iniciada', '12:20:28', '2013-03-05', 'rolignu86255', 0),
('NTNP70832539154', 'Sesion Iniciada', '22:18:54', '2013-03-14', 'rolignu86255', 0),
('NTNP708479523438', 'Sesion Iniciada', '18:45:47', '2013-03-14', 'rolignu86255', 0),
('NTNP710138356738', 'Sesion Iniciada', '11:52:07', '2013-03-05', 'rolignu86255', 0),
('NTNP712727522948', 'Sesion Iniciada', '21:34:17', '2013-02-28', '2', 0),
('NTNP71379718840', 'Sesion Iniciada', '16:37:30', '2013-03-01', '2', 0),
('NTNP714386355250', 'Sesion Iniciada', '19:04:17', '2013-03-14', 'rolignu86255', 0),
('NTNP71545620340', 'Sesion Iniciada', '14:30:38', '2013-03-25', 'rolignu86255', 0),
('NTNP723228600347', 'Sesion Iniciada', '17:50:12', '2013-03-02', '32', 0),
('NTNP727681516752', 'Sesion Iniciada', '22:12:04', '2013-03-14', 'rolignu86255', 0),
('NTNP728546265948', 'Sesion Iniciada', '23:27:49', '2013-03-15', 'rolignu86255', 0),
('NTNP730135431159', 'Sesion Iniciada', '12:46:31', '2013-03-05', 'rolignu86255', 0),
('NTNP732793264459', 'Sesion Iniciada', '19:09:52', '2013-02-28', '2', 0),
('NTNP73465813655', 'Sesion Iniciada', '19:04:07', '2013-03-14', 'rolignu86255', 0),
('NTNP73545396760', 'Sesion Iniciada', '17:54:54', '2013-03-02', 'herberth71737', 0),
('NTNP73711292861', 'Producto 1 Ha sido eliminado de la lista ', '18:16:09', '2013-03-01', '2', 5),
('NTNP739976676256', 'Cerro sesion ', '23:26:55', '2013-03-02', 'rolignu86255', 1),
('NTNP741565843466', 'Sesion Iniciada', '12:19:16', '2013-03-05', 'rolignu86255', 0),
('NTNP74688350868', 'Sesion Iniciada', '23:12:35', '2013-03-02', '31', 0),
('NTNP747748257263', 'Sesion Iniciada', '12:04:42', '2013-03-22', 'rolignu86255', 0),
('NTNP747953174158', 'Sesion Iniciada', '21:13:08', '2013-03-22', 'rolignu86255', 0),
('NTNP748542340369', 'Sesion Iniciada', '17:11:07', '2013-03-02', '32', 0),
('NTNP75040789564', 'Sesion Iniciada', '23:26:41', '2013-03-02', 'rolignu86255', 0),
('NTNP75266921864', 'Sesion Iniciada', '21:44:11', '2013-03-14', 'rolignu86255', 0),
('NTNP756519837271', 'Cerro sesion ', '11:10:17', '2013-03-02', 'rolignu86255', 1),
('NTNP75945287860', 'Sesion Iniciada', '11:37:51', '2013-03-05', 'rolignu86255', 0),
('NTNP7632316622', 'Sesion Iniciada', '12:36:09', '2013-03-25', 'rolignu86255', 0),
('NTNP764291417278', 'Cerro sesion ', '14:00:21', '2013-03-05', 'rolignu86255', 1),
('NTNP768814997774', 'Sesion Iniciada', '12:15:28', '2013-03-05', 'rolignu86255', 0),
('NTNP77147483075', 'Sesion Iniciada', '17:29:14', '2013-03-15', 'rolignu86255', 0),
('NTNP772268913180', 'Sesion Iniciada', '11:45:12', '2013-03-14', 'rolignu86255', 0),
('NTNP77263997285', 'producto agregado Cod:(PN2055566336 ) Nombre: sd', '14:39:47', '2013-03-04', 'rolignu86255', 2),
('NTNP777380661886', 'Sesion Iniciada', '18:59:36', '2013-03-01', '2', 0),
('NTNP781904243382', 'Sesion Iniciada', '11:54:54', '2013-02-28', '2', 0),
('NTNP782698326487', 'Sesion Iniciada', '18:11:31', '2013-03-02', '5', 0),
('NTNP785358159788', 'Producto fsds Ha sido eliminado de la lista ', '14:40:09', '2013-03-04', 'rolignu86255', 5),
('NTNP786152242893', 'Sesion Iniciada', '13:50:06', '2013-03-05', 'rolignu86255', 0),
('NTNP789881739285', 'Sesion Iniciada', '21:37:16', '2013-03-15', 'rolignu86255', 0),
('NTNP790675822390', 'Sesion Iniciada', '20:57:35', '2013-03-01', '2', 0),
('NTNP791540571585', 'Sesion Iniciada', '21:18:22', '2013-03-15', 'rolignu86255', 0),
('NTNP793129738795', 'Cerro sesion ', '11:13:32', '2013-03-02', 'herberth71737', 1),
('NTNP79399203266', 'Cerro sesion ', '21:17:56', '2013-03-01', '32', 1),
('NTNP79678857096', 'producto agregado Cod:(PN666 ) Nombre: Consome ', '21:48:41', '2013-02-28', '2', 2),
('NTNP800312152592', 'Sesion Iniciada', '23:31:59', '2013-03-15', 'rolignu86255', 0),
('NTNP80264951461', 'Sesion Iniciada', '14:40:10', '2013-03-04', 'rolignu86255', 0),
('NTNP814196479306', 'Sesion Iniciada', '23:52:15', '2013-03-14', 'rolignu86255', 0),
('NTNP81661228501', 'Sesion Iniciada', '11:10:01', '2013-03-02', 'rolignu86255', 0),
('NTNP816854312606', 'Sesion Iniciada', '11:12:45', '2013-03-05', 'rolignu86255', 0),
('NTNP817649395711', 'Sesion Iniciada', '12:41:58', '2013-03-15', 'rolignu86255', 0),
('NTNP819514144907', 'Sesion Iniciada', '18:08:20', '2013-03-01', '2', 0),
('NTNP820379892103', 'Sesion Iniciada', '15:47:46', '2013-03-16', 'rolignu86255', 0),
('NTNP821173976208', 'Sesion Iniciada', '22:29:14', '2013-03-05', 'rolignu86255', 0),
('NTNP825626891614', 'Sesion Iniciada', '20:08:40', '2013-03-01', '2', 0),
('NTNP827285724914', 'Producto 1 Ha sido eliminado de la lista ', '18:18:12', '2013-03-01', '2', 5),
('NTNP830944556215', 'Sesion Iniciada', '23:23:39', '2013-03-02', 'rolignu86255', 0),
('NTNP832603388516', 'Sesion Iniciada', '17:25:45', '2013-03-02', '32', 0),
('NTNP833398472621', 'producto agregado Cod:(PN56666 ) Nombre: prod con decimal', '12:46:22', '2013-03-05', 'rolignu86255', 2),
('NTNP834468137711', 'Sesion Iniciada', '19:04:29', '2013-03-14', 'rolignu86255', 0),
('NTNP835263221816', 'Cerro sesion ', '18:53:55', '2013-03-01', '30', 1),
('NTNP840580885418', 'Sesion Iniciada', '16:03:53', '2013-03-26', 'rolignu86255', 0),
('NTNP842240717718', 'Sesion Iniciada', '16:38:56', '2013-03-01', '32', 0),
('NTNP84334800823', 'Sesion Iniciada', '18:57:22', '2013-03-22', 'rolignu86255', 0),
('NTNP845693633125', 'Cerro sesion ', '17:32:01', '2013-03-15', 'rolignu86255', 1),
('NTNP847558382320', 'Sesion Iniciada', '21:42:46', '2013-02-28', '2', 0),
('NTNP848352465425', 'Sesion Iniciada', '15:32:04', '2013-03-16', 'rolignu86255', 0),
('NTNP850217214620', 'Sesion Iniciada', '12:20:44', '2013-03-25', 'rolignu86255', 0),
('NTNP854464213132', 'producto agregado Cod:(PU456699 ) Nombre: prueba usado', '14:09:58', '2013-03-15', 'herberth71737', 2),
('NTNP855329961327', 'Cerro sesion ', '22:50:49', '2013-03-02', 'herberth71737', 1),
('NTNP85612446432', 'Sesion Iniciada', '12:10:12', '2013-03-22', 'rolignu86255', 0),
('NTNP859577960837', 'Sesion Iniciada', '17:54:27', '2013-03-19', 'rolignu86255', 0),
('NTNP860647626928', 'Sesion Iniciada', '21:36:33', '2013-03-01', '32', 0),
('NTNP86144270934', 'Sesion Iniciada', '15:19:55', '2013-03-16', 'rolignu86255', 0),
('NTNP86376699168', 'Sesion Iniciada', '23:00:48', '2013-03-02', 'herberth71737', 0),
('NTNP864895625439', 'Sesion Iniciada', '23:43:24', '2013-03-23', 'rolignu86255', 0),
('NTNP865965291530', 'Sesion Iniciada', '18:13:57', '2013-03-01', '2', 0),
('NTNP866759374635', 'Cerro sesion ', '21:24:41', '2013-03-01', '32', 1),
('NTNP867554458740', 'producto agregado Cod:(dfdf ) Nombre: fdf', '14:43:11', '2013-03-04', 'rolignu86255', 2),
('NTNP869419206935', 'Sesion Iniciada', '11:00:20', '2013-03-02', 'herberth71737', 0),
('NTNP874737870537', 'Sesion Iniciada', '12:25:16', '2013-03-22', 'rolignu86255', 0),
('NTNP87532638747', 'Sesion Iniciada', '14:36:01', '2013-03-27', 'rolignu86255', 0),
('NTNP876396703837', 'Sesion Iniciada', '23:43:27', '2013-03-14', 'rolignu86255', 0),
('NTNP877190786942', 'Sesion Iniciada', '22:30:25', '2013-03-05', 'rolignu86255', 0),
('NTNP87898486948', 'Sesion Iniciada', '12:11:31', '2013-03-25', 'rolignu86255', 0),
('NTNP87955535138', 'Cerro sesion ', '18:43:52', '2013-03-01', '2', 1),
('NTNP879849618243', 'Cerro sesion ', '11:13:18', '2013-03-02', 'rolignu86255', 1),
('NTNP880643702349', 'Sesion Iniciada', '19:06:21', '2013-03-14', 'rolignu86255', 0),
('NTNP882508451544', 'Cerro sesion ', '18:01:52', '2013-03-19', 'douglas21508', 1),
('NTNP884168283844', 'Cerro sesion ', '21:04:20', '2013-03-01', '32', 1),
('NTNP89028031551', 'producto agregado Cod:(PN45566355 ) Nombre: cambioPP', '19:09:10', '2013-03-14', 'herberth71737', 2),
('NTNP8935532469', 'Sesion Iniciada', '18:28:44', '2013-03-26', 'rolignu86255', 0),
('NTNP89480361248', 'Sesion Iniciada', '21:15:27', '2013-03-15', 'rolignu86255', 0),
('NTNP896392779258', 'Cerro sesion ', '18:06:36', '2013-03-02', '32', 1),
('NTNP89852611558', 'Sesion Iniciada', '21:05:35', '2013-03-14', 'rolignu86255', 0),
('NTNP901710443859', 'Sesion Iniciada', '19:42:32', '2013-02-28', '2', 0),
('NTNP903369276160', 'Sesion Iniciada', '18:17:37', '2013-03-01', '2', 0),
('NTNP90523424355', 'Sesion Iniciada', '11:34:24', '2013-03-14', 'herberth71737', 0),
('NTNP910552688956', 'Sesion Iniciada', '14:00:03', '2013-03-25', 'rolignu86255', 0),
('NTNP916664436663', 'Sesion Iniciada', '12:46:36', '2013-03-09', 'herberth71737', 0),
('NTNP91694364769', 'Sesion Iniciada', '12:31:13', '2013-03-27', 'rolignu86255', 0),
('NTNP91911835269', 'Cerro sesion ', '20:01:03', '2013-03-01', '30', 1),
('NTNP920912436174', 'Sesion Iniciada', '14:03:00', '2013-03-28', 'rolignu86255', 0),
('NTNP921982101265', 'Sesion Iniciada', '21:40:34', '2013-03-22', 'rolignu86255', 0),
('NTNP923571268475', 'Sesion Iniciada', '11:32:49', '2013-03-14', 'herberth71737', 0),
('NTNP923642933565', 'Sesion Iniciada', '11:10:58', '2013-03-21', 'rolignu86255', 0),
('NTNP926301765865', 'Sesion Iniciada', '21:09:42', '2013-03-14', 'rolignu86255', 0),
('NTNP92788993276', 'Sesion Iniciada', '21:31:19', '2013-02-28', '2', 0),
('NTNP932413513572', 'Sesion Iniciada', '13:21:38', '2013-03-25', 'rolignu86255', 0),
('NTNP937526261279', 'Cerro sesion ', '23:30:58', '2013-03-02', 'rolignu86255', 1),
('NTNP941979177684', 'Sesion Iniciada', '14:51:10', '2013-03-14', 'rolignu86255', 0),
('NTNP948956673586', 'Sesion Iniciada', '16:43:45', '2013-03-16', 'rolignu86255', 0),
('NTNP949765817', 'Sesion Iniciada', '12:06:44', '2013-03-14', 'rolignu86255', 0),
('NTNP951615506887', 'Sesion Iniciada', '22:51:43', '2013-03-05', 'rolignu86255', 0),
('NTNP95248025483', 'Sesion Iniciada', '16:10:29', '2013-03-26', 'rolignu86255', 0),
('NTNP953274338188', 'Sesion Iniciada', '18:14:38', '2013-03-02', '32', 0),
('NTNP95513987383', 'Sesion Iniciada', '15:43:28', '2013-03-04', 'rolignu86255', 0),
('NTNP957727254594', 'Sesion Iniciada', '20:00:54', '2013-03-01', '30', 0),
('NTNP95938786894', 'Cerro sesion ', '16:38:41', '2013-03-01', '2', 1),
('NTNP963910666391', 'Sesion Iniciada', '20:40:30', '2013-03-10', 'rolignu86255', 0),
('NTNP966569499691', 'Sesion Iniciada', '12:24:40', '2013-03-05', 'rolignu86255', 0),
('NTNP967364582796', 'Sesion Iniciada', '14:15:01', '2013-03-25', 'rolignu86255', 0),
('NTNP9692341597', 'Sesion Iniciada', '17:29:35', '2013-03-15', 'rolignu86255', 0),
('NTNP970817498202', 'Sesion Iniciada', '23:33:29', '2013-03-15', 'rolignu86255', 0),
('NTNP971682247398', 'Sesion Iniciada', '21:39:44', '2013-02-28', '2', 0),
('NTNP977794994105', 'Sesion Iniciada', '18:32:14', '2013-03-26', 'rolignu86255', 0),
('NTNP97806112476', 'Sesion Iniciada', '12:09:42', '2013-03-05', 'rolignu86255', 0),
('NTNP981248910510', 'Sesion Iniciada', '15:04:06', '2013-03-28', 'rolignu86255', 0),
('NTNP981318575600', 'Sesion Iniciada', '14:38:42', '2013-03-04', 'rolignu86255', 0),
('NTNP9857714917', 'Sesion Iniciada', '12:01:07', '2013-03-14', 'rolignu86255', 0),
('NTNP986566575112', 'Sesion Iniciada', '13:50:03', '2013-03-14', 'rolignu86255', 0),
('NTNP987431324307', 'Cerro sesion ', '21:06:37', '2013-03-01', '2', 1),
('NTNP988225407412', 'Sesion Iniciada', '18:12:18', '2013-03-02', 'herberth71737', 0),
('NTNP991884239712', 'Sesion Iniciada', '22:16:53', '2013-02-28', '2', 0),
('NTNP992748987908', 'Sesion Iniciada', '20:32:47', '2013-03-01', '2', 0),
('NTNP9935437214', 'Sesion Iniciada', '12:16:18', '2013-03-22', 'rolignu86255', 0),
('NTNP995408820209', 'Sesion Iniciada', '16:29:42', '2013-03-16', 'rolignu86255', 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pnuevos`
--

CREATE TABLE `pnuevos` (
  `idpnuevos` varchar(255) NOT NULL,
  `nombre` varchar(255) NOT NULL,
  `fecha` date NOT NULL,
  `precio` decimal(10,3) DEFAULT NULL,
  `cantidad` int(255) NOT NULL,
  `descuentos` varchar(255) NOT NULL,
  `garantia` varchar(255) NOT NULL,
  `idsucursal` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `pnuevos`
--

INSERT INTO `pnuevos` (`idpnuevos`, `nombre`, `fecha`, `precio`, `cantidad`, `descuentos`, `garantia`, `idsucursal`) VALUES
('TYU0120324', 'VENTILADOR DE 1/2', '2013-03-05', 550.000, 200, '10', '1', 'Su1002011'),
('PN100105', 'compresor', '2013-03-13', 400.000, 10, '4', '10', 'Su1002011'),
('PN2222', 'gatorade', '2013-03-14', 4.000, 10, 'No', 'No', 'Su1002011'),
('PN4555', 'prueba', '2013-03-14', 4.000, 10, 'No', 'No', 'Su1003011'),
('PN456636', 'canon laser', '2013-03-21', 45.000, 5, 'No', 'No', 'Su1002011'),
('PN2002336', 'CALENTADOR', '2013-03-29', 40.000, 10, '20', ' 12', 'Su1002011');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `productos`
--

CREATE TABLE `productos` (
  `idproductos` varchar(255) NOT NULL,
  `idpusados` varchar(255) NOT NULL,
  `idpnuevos` varchar(255) NOT NULL,
  `existente` int(1) NOT NULL,
  `activo` int(1) NOT NULL,
  `idproveedores` varchar(255) NOT NULL,
  `idsucursal` varchar(255) NOT NULL,
  PRIMARY KEY (`idproductos`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `productos`
--

INSERT INTO `productos` (`idproductos`, `idpusados`, `idpnuevos`, `existente`, `activo`, `idproveedores`, `idsucursal`) VALUES
('PROD04811', 'PU200547889', 'NULL', 1, 1, 'PROV19701426', 'Su1002011'),
('PROD3869', 'NULL', 'PN2002336', 1, 1, 'PROV92203515', 'Su1002011'),
('PROD4187', 'PU55664', 'NULL', 1, 1, 'PROV19701426', 'Su1002011'),
('PROD4226', 'NULL', 'PN4555', 0, 0, 'PROV76655815', 'Su1003011'),
('PROD4410', 'PN10052040', 'NULL', 0, 0, 'PROV36325022', 'Su1002011'),
('PROD4716', 'NULL', 'PN2222', 1, 0, 'PROV2538851', 'Su1002011'),
('PROD63411', 'PU456699999', 'NULL', 1, 1, 'PROV19701426', 'Su1003011'),
('PROD6838', 'NULL', 'PN100105', 1, 1, 'PROV39152120', 'Su1002011'),
('PROD7638', 'PU456699', 'NULL', 1, 1, 'PROV19701426', 'Su1003011'),
('PROD7888', 'NULL', 'PN456636', 1, 0, 'PROV36325022', 'Su1002011'),
('PROD85610', 'NULL', 'TYU0120324', 1, 1, 'PROV19701426', 'Su1002011'),
('PROD8658', 'PU100105', 'NULL', 0, 0, 'PROV39152120', 'Su1002011');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `Proveedores`
--

CREATE TABLE `Proveedores` (
  `idproveedor` varchar(255) NOT NULL,
  `nombre` varchar(255) NOT NULL,
  `direccion` varchar(255) DEFAULT NULL,
  `telefono` varchar(9) NOT NULL,
  `sitioweb` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`idproveedor`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `Proveedores`
--

INSERT INTO `Proveedores` (`idproveedor`, `nombre`, `direccion`, `telefono`, `sitioweb`) VALUES
('PROV19701426', 'herberth', 'cd', '22122202', 'telefe.com'),
('PROV2538851', 'bc-db', '29 ave norte, por la nacional', '22857412', ''),
('PROV295791219', 'avon', '', '2262-3366', 'http://www.avon.com'),
('PROV36325022', 'cualitas', '79 ave sur cualitas s.a de c.v', '22745981', 'www.cualitas.com'),
('PROV39152120', 'rolando', '75 ave norte calle mano de leon', '22620282', 'www.rsoft.com'),
('PROV459306252', 'asesuisa', '75 ave norte ', '2262-0282', 'http://'),
('PROV53339910', 'sonya', 'avenida park ', '22664455', 'www.sonya.com'),
('PROV66839362', 'industrias compresor', '75 ave norte calle mano de leon', '22654885', ''),
('PROV76655815', 'marco tulio', 'restringida', '55255665', 'www.tulito.com'),
('PROV92203515', 'nwork', '', '22645899', 'www.nwork.ideas.com');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pusados`
--

CREATE TABLE `pusados` (
  `idpusado` varchar(255) NOT NULL,
  `nombre` varchar(255) NOT NULL,
  `fecha` date NOT NULL,
  `estado` text NOT NULL,
  `precio` decimal(10,3) NOT NULL,
  `descuento` varchar(255) NOT NULL,
  `garantia` varchar(255) NOT NULL,
  `cantidad` int(11) NOT NULL,
  `idsucursal` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `pusados`
--

INSERT INTO `pusados` (`idpusado`, `nombre`, `fecha`, `estado`, `precio`, `descuento`, `garantia`, `cantidad`, `idsucursal`) VALUES
('PU200547889', 'ventilador 115/100', '2013-03-14', 'No hay descripcion', 45.000, '15', 'No', 5, 'Su1002011'),
('PU100105', 'condensadro 45pf', '2013-03-14', 'Condensador capacidad 45pf a 115v', 0.500, 'No', 'No', 1500, 'Su1002011'),
('PU55664', 'tuercas varias 5mm', '2013-03-14', 'No hay descripcion', 0.800, 'No', 'No', 15000, 'Su1002011'),
('PU456699', 'prueba usado', '2013-03-13', 'No hay descripcion', 155.000, 'No', 'No', 10, 'Su1003011'),
('PU456699999', 'prueba usado', '2013-03-13', 'No hay descripcion', 155.000, 'No', 'No', 10, 'Su1003011'),
('PN10052040', '455663663', '2013-03-23', 'No hay descripcion', 100.000, '10', '4', 100, 'Su1002011');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sucursal`
--

CREATE TABLE `sucursal` (
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
('Su1012011', 'Soyapango', 'soyapango centro ', '22845566', 'Herberth Gonzales'),
('SUCG282123', 'guatemala , ciudad de guatemala', 'no hay', '25856633', 'gonzalo merendes');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `User_login`
--

CREATE TABLE `User_login` (
  `iduser` varchar(255) NOT NULL DEFAULT '',
  `username` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `estado` varchar(255) NOT NULL,
  `tipo` varchar(255) NOT NULL,
  `sesion` int(11) NOT NULL,
  PRIMARY KEY (`iduser`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `User_login`
--

INSERT INTO `User_login` (`iduser`, `username`, `email`, `password`, `estado`, `tipo`, `sesion`) VALUES
('douglas21508', 'douglas', '', 'linux', '1', 'user	', 0),
('peter20443', 'peter', '', 'peter', '1', 'user	', 0),
('alsajib03127', 'alsajib', '', 'root', '1', 'user	', 0),
('herberth247453', 'herberth2', '', 'chino', '1', 'admin', 0),
('herberth71737', 'herberth', '', 'windows', '1', 'admin', 0),
('tulio74640', 'tulio', '', 'tulio', '1', 'user	', 0),
('rolignu86255', 'rolignu', '', 'linux', '1', 'admin', 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ventas`
--

CREATE TABLE `ventas` (
  `id_ventas` varchar(255) NOT NULL,
  `id_clientes` varchar(255) NOT NULL,
  `total_ventas` varchar(255) NOT NULL,
  PRIMARY KEY (`id_ventas`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
