using System;
using System.IO;

namespace SpencerStuartTest.ThreeJS
{
	/// <summary>
	/// A very ugly and singular HTML parser
	/// </summary>
	public class SceneBuilder
	{
		private string htmlFileFullPath;

		public SceneBuilder(string htmlFileFullPath)
		{
			this.htmlFileFullPath = htmlFileFullPath;
			var stream = File.CreateText(htmlFileFullPath);
			stream.Write(pre);
			stream.Close();
		}

		public void Appendy(string s)
		{
			File.AppendAllText(htmlFileFullPath, s);
		}

		public void Finish()
		{
			Appendy(post);
		}

		public void AddSafestPoint(int[] safestPoint)
		{
			string replacey = @"
					geometry = new THREE.SphereGeometry( 20, 32, 16 );
					material = new THREE.MeshLambertMaterial( { color: 0xff0088 } );
					mesh = new THREE.Mesh( geometry, material );
					";
			replacey += string.Format("mesh.position.set({0}, {1}, {2});", safestPoint[0], safestPoint[1], safestPoint[2]);
			replacey += @"
					scene.add(mesh);";
			Appendy(replacey);
		}

		public void AddBomb(int[] point)
		{
			string replacey = (@"
	geometry = new THREE.SphereGeometry( 10, 32, 16 );
	material = new THREE.MeshLambertMaterial( { color: 0x000088 } );
	mesh = new THREE.Mesh( geometry, material );
");
			replacey += string.Format("mesh.position.set({0}, {1}, {2});", point[0], point[1], point[2]);
			replacey += @"
scene.add(mesh);
";
			Appendy(replacey);
		}

		private static string pre = @"
<!doctype html>
<html lang=""en"">
<head>
    <title>Exercise 2</title>
    <meta charset=""utf-8"">
    <meta name=""viewport"" content=""width=device-width, user-scalable=no, minimum-scale=1.0, maximum-scale=1.0"">
    <link rel=stylesheet href=""css/base.css""/>
</head>
<body>

<script src=""js/Three.js""></script>
<script src=""js/Detector.js""></script>
<script src=""js/Stats.js""></script>
<script src=""js/OrbitControls.js""></script>
<script src=""js/THREEx.KeyboardState.js""></script>
<script src=""js/THREEx.FullScreen.js""></script>
<script src=""js/THREEx.WindowResize.js""></script>

<!-- Code to display an information button and box when clicked. -->
<script src=""http://code.jquery.com/jquery-1.9.1.js""></script>
<script src=""http://code.jquery.com/ui/1.10.2/jquery-ui.js""></script>
<link rel=stylesheet href=""http://code.jquery.com/ui/1.10.2/themes/smoothness/jquery-ui.css"" />
<link rel=stylesheet href=""css/info.css""/>
<script src=""js/info.js""></script>
<!-- ------------------------------------------------------------ -->

<div id=""ThreeJS"" style=""z-index: 1; position: absolute; left:0px; top:0px""></div>
<script>
/*
	Three.js ""Stealing from Stemkoski""
	Author: Anon
	Date: Feb 2017
 */
// MAIN
// standard global variables
var container, scene, camera, renderer, controls, stats;
var keyboard = new THREEx.KeyboardState();
var clock = new THREE.Clock();
// custom global variables
var mesh;
init();
animate();
// FUNCTIONS 		
function init() 
{
	// SCENE
	scene = new THREE.Scene();
	// CAMERA
	var SCREEN_WIDTH = window.innerWidth, SCREEN_HEIGHT = window.innerHeight;
	var VIEW_ANGLE = 45, ASPECT = SCREEN_WIDTH / SCREEN_HEIGHT, NEAR = 0.1, FAR = 20000;
	camera = new THREE.PerspectiveCamera( VIEW_ANGLE, ASPECT, NEAR, FAR);
	scene.add(camera);
	camera.position.set(0,150,400);
	camera.lookAt(scene.position);	
	// RENDERER
	if ( Detector.webgl )
		renderer = new THREE.WebGLRenderer( {antialias:true} );
	else
		renderer = new THREE.CanvasRenderer(); 
	renderer.setSize(SCREEN_WIDTH, SCREEN_HEIGHT);
	container = document.getElementById( 'ThreeJS' );
	container.appendChild( renderer.domElement );
	// EVENTS
	THREEx.WindowResize(renderer, camera);
	THREEx.FullScreen.bindKey({ charCode : 'm'.charCodeAt(0) });
	// CONTROLS
	controls = new THREE.OrbitControls( camera, renderer.domElement );
	// STATS
	stats = new Stats();
	stats.domElement.style.position = 'absolute';
	stats.domElement.style.bottom = '0px';
	stats.domElement.style.zIndex = 100;
	container.appendChild( stats.domElement );
	// LIGHT
	var light = new THREE.PointLight(0xffffff);
	light.position.set(100,250,100);
	scene.add(light);
	
	////////////
	// CUSTOM //
	////////////
	
	var axes = new THREE.AxisHelper(50);
	axes.position.set(0,0,0);
	scene.add(axes);
	
	var gridXZ = new THREE.GridHelper(500, 10);
	gridXZ.setColors( new THREE.Color(0x006600), new THREE.Color(0x006600) );
	gridXZ.position.set( 500,0,500 );
	scene.add(gridXZ);
	
	var gridXY = new THREE.GridHelper(500, 10);
	gridXY.position.set( 500,500,0 );
	gridXY.rotation.x = Math.PI/2;
	gridXY.setColors( new THREE.Color(0x000066), new THREE.Color(0x000066) );
	scene.add(gridXY);
	var gridYZ = new THREE.GridHelper(500, 10);
	gridYZ.position.set( 0,500,500 );
	gridYZ.rotation.z = Math.PI/2;
	gridYZ.setColors( new THREE.Color(0x660000), new THREE.Color(0x660000) );
	scene.add(gridYZ);
var geometry = new THREE.SphereGeometry( 20, 32, 16 );
var material = new THREE.MeshLambertMaterial( { color: 0x000088 } );";

		private static string post = @"
}
function animate() 
{
    requestAnimationFrame( animate );
	render();		
	update();
}
function update()
{
	if ( keyboard.pressed(""z"") ) 
	{	// do something   
	}
	
	controls.update();
	stats.update();
}
	function render()
	{
		renderer.render(scene, camera);
	}
</script>

</body>
	</html>";
	}
}
