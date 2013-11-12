<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fandashboard.aspx.cs" Inherits="zfitWebApp.fandashboard" %>

<!DOCTYPE html>
<html lang="en" class="no-js">
	<head>
		<meta charset="UTF-8" />
		<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"> 
		<meta name="viewport" content="width=device-width, initial-scale=1.0"> 
		<title>Sidebar Transitions</title>
		<meta name="description" content="Sidebar Transitions: Transition effects for off-canvas views" />
		<meta name="keywords" content="transition, off-canvas, navigation, effect, 3d, css3, smooth" />
		<meta name="author" content="Codrops" />
		<%--<link rel="shortcut icon" href="../favicon.ico">--%>
		<link rel="stylesheet" type="text/css" href="styles/normalize.css" />
		<link rel="stylesheet" type="text/css" href="styles/demo.css" />
		<link rel="stylesheet" type="text/css" href="styles/icons.css" />
		<link rel="stylesheet" type="text/css" href="styles/dashboard.css" />
		<script src="js/modernizr.custom.js"></script>
	</head>
	<body>
		<div id="st-container" class="st-container">
			<!-- content push wrapper -->
			<div class="st-pusher">
				<nav class="st-menu st-effect-6" id="menu-6">
					<h2 class="icon icon-stack">Sidebar</h2>
					<ul>
						<li><a class="icon icon-data" href="#">My Profile</a></li>
						<li><a class="icon icon-location" href="#">My Workouts</a></li>
						<li><a class="icon icon-study" href="#">My Boxes</a></li>
						<li><a class="icon icon-photo" href="#">The Community</a></li>
					</ul>
				</nav>

				<div class="st-content"><!-- this is the wrapper for the content -->
					<div class="st-content-inner"><!-- extra div for emulating position:fixed of the menu -->
						<!-- Top Navigation -->

						<header class="codrops-header">
							<h1>Welcome to TotalFitness<span>How fit are you really?</span></h1>
						</header>
						<div class="main clearfix">
							<div id="st-trigger-effects" class="column">
								<button data-effect="st-effect-6">+</button>
							</div>
							<div class="column">
								<p>Sidebar menus or off-canvas navigations can be revealed in many creative ways.</p>
								<p>Here is some inspiration for showing them in style using CSS transitions.</p>
							</div>
							<div class="info">
								<p>If you enjoyed this demo you might also like:</p>
								<p><a href="http://tympanus.net/Development/HeaderEffects/">On Scroll Header Effects</a></p>
								<p><a href="http://tympanus.net/Development/PageTransitions/">A Collection of Page Transitions</a></p>
							</div>
						</div><!-- /main -->
					</div><!-- /st-content-inner -->
				</div><!-- /st-content -->
			</div><!-- /st-pusher -->
		</div><!-- /st-container -->
		<script src="scripts/classie.js"></script>
		<script src="scripts/sidebarEffects.js"></script>
	</body>
</html>
