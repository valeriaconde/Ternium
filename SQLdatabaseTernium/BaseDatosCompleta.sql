-- MySQL dump 10.13  Distrib 8.0.24, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: bitacora
-- ------------------------------------------------------
-- Server version	8.0.24

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `bitacora`
--

DROP TABLE IF EXISTS `bitacora`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bitacora` (
  `idbitacora` int NOT NULL AUTO_INCREMENT,
  `Username` varchar(50) NOT NULL,
  `Hora_Entrada` datetime NOT NULL,
  PRIMARY KEY (`idbitacora`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bitacora`
--

LOCK TABLES `bitacora` WRITE;
/*!40000 ALTER TABLE `bitacora` DISABLE KEYS */;
INSERT INTO `bitacora` VALUES (1,'TecEquipo5','2021-05-28 00:00:00'),(15,'TecEquipo5','2021-05-30 00:00:00'),(16,'TecEquipo5','2021-05-30 00:00:00');
/*!40000 ALTER TABLE `bitacora` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `catalogo_de_categorias`
--

DROP TABLE IF EXISTS `catalogo_de_categorias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `catalogo_de_categorias` (
  `CategoriaID` int NOT NULL,
  `Descripcion` varchar(250) NOT NULL,
  PRIMARY KEY (`CategoriaID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `catalogo_de_categorias`
--

LOCK TABLES `catalogo_de_categorias` WRITE;
/*!40000 ALTER TABLE `catalogo_de_categorias` DISABLE KEYS */;
/*!40000 ALTER TABLE `catalogo_de_categorias` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `catalogo_de_medallas`
--

DROP TABLE IF EXISTS `catalogo_de_medallas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `catalogo_de_medallas` (
  `MedallaID` int NOT NULL AUTO_INCREMENT,
  `CategoriaID` int NOT NULL,
  `Descripcion` varchar(250) NOT NULL,
  PRIMARY KEY (`MedallaID`),
  KEY `CategoriaID_idx` (`CategoriaID`),
  CONSTRAINT `CategoriaID` FOREIGN KEY (`CategoriaID`) REFERENCES `catalogo_de_categorias` (`CategoriaID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `catalogo_de_medallas`
--

LOCK TABLES `catalogo_de_medallas` WRITE;
/*!40000 ALTER TABLE `catalogo_de_medallas` DISABLE KEYS */;
/*!40000 ALTER TABLE `catalogo_de_medallas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `catalogo_materiales`
--

DROP TABLE IF EXISTS `catalogo_materiales`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `catalogo_materiales` (
  `MaterialID` int NOT NULL AUTO_INCREMENT,
  `Nombre_Material` varchar(45) NOT NULL,
  PRIMARY KEY (`MaterialID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `catalogo_materiales`
--

LOCK TABLES `catalogo_materiales` WRITE;
/*!40000 ALTER TABLE `catalogo_materiales` DISABLE KEYS */;
/*!40000 ALTER TABLE `catalogo_materiales` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `juego`
--

DROP TABLE IF EXISTS `juego`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `juego` (
  `PartidaID` int NOT NULL AUTO_INCREMENT,
  `Usuario` int NOT NULL,
  `Puntaje_Total` int NOT NULL,
  `Nivel_Alcanzado` int NOT NULL,
  PRIMARY KEY (`PartidaID`),
  KEY `Usuario_ID_idx` (`Usuario`),
  CONSTRAINT `UserID` FOREIGN KEY (`Usuario`) REFERENCES `usuario` (`Usuario_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `juego`
--

LOCK TABLES `juego` WRITE;
/*!40000 ALTER TABLE `juego` DISABLE KEYS */;
INSERT INTO `juego` VALUES (1,2,5000,6),(2,4,2600,3),(3,1,1000,2),(4,5,5500,6),(5,3,3000,4);
/*!40000 ALTER TABLE `juego` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `materiales_equivocados`
--

DROP TABLE IF EXISTS `materiales_equivocados`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `materiales_equivocados` (
  `PartidaID` int NOT NULL,
  `MaterialID` int NOT NULL,
  `Cantidad_Total` int NOT NULL,
  PRIMARY KEY (`PartidaID`,`MaterialID`),
  KEY `MaterialID_idx` (`MaterialID`),
  CONSTRAINT `MaterialID` FOREIGN KEY (`MaterialID`) REFERENCES `catalogo_materiales` (`MaterialID`),
  CONSTRAINT `PartidaID` FOREIGN KEY (`PartidaID`) REFERENCES `juego` (`PartidaID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `materiales_equivocados`
--

LOCK TABLES `materiales_equivocados` WRITE;
/*!40000 ALTER TABLE `materiales_equivocados` DISABLE KEYS */;
/*!40000 ALTER TABLE `materiales_equivocados` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `medallas`
--

DROP TABLE IF EXISTS `medallas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `medallas` (
  `MedallaID` int NOT NULL,
  `Usuario_ID` int NOT NULL,
  `nivelMedalla` int NOT NULL,
  `icono` varchar(50) NOT NULL,
  PRIMARY KEY (`MedallaID`,`Usuario_ID`),
  KEY `Usuario_ID_idx` (`Usuario_ID`),
  CONSTRAINT `MedallaID` FOREIGN KEY (`MedallaID`) REFERENCES `catalogo_de_medallas` (`MedallaID`),
  CONSTRAINT `UsuarioID` FOREIGN KEY (`Usuario_ID`) REFERENCES `usuario` (`Usuario_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `medallas`
--

LOCK TABLES `medallas` WRITE;
/*!40000 ALTER TABLE `medallas` DISABLE KEYS */;
/*!40000 ALTER TABLE `medallas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuario` (
  `Usuario_ID` int NOT NULL AUTO_INCREMENT,
  `Username` varchar(45) NOT NULL,
  PRIMARY KEY (`Usuario_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,'Pablo'),(2,'Jose'),(3,'Hector'),(4,'Maria'),(5,'Arturo');
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-05-31 23:07:04
